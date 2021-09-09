﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.Toast.Services;
using Chronos.Models;
using Chronos.Models.Enums;
using Chronos.Shared.Enums;
using Chronos.Shared.Wrappers;
using Microsoft.AspNetCore.Components;

namespace Chronos.Pages
{
    public partial class DegreePlan
    {
        // Cascaded Parameters
        public Degree Degree { get; private set; }
        public Major Major { get; private set; }
        public AvailableCampus Campus { get; private set; }


        private int blockSize = 2;
        private bool fiftyUnitsWarningBool = false;

        private bool isReady = false;
        private String warnings = "";
        private String errors = "";

        //Dragging Variables
        public TileData DragPayload { get; set; }
        public List<TileData> DragFrom { get; set; }
        public CourseRuntime BlockTypeFrom { get; set; }


        public int ErrorCount { get; set; }
        public int WarningCount { get; set; }

        //Updates the degree plan after a drag
        public async Task UpdateDegreePlanAsync(List<TileData> dragTo, TileData draggedOn, CourseRuntime blockTypeTo)
        {
            if (DragPayload.Course is not null && (blockTypeTo & DragPayload.Runtime) == 0)
            {
                ToastService.ShowToast(ToastLevel.Error, $"{DragPayload.Course.CourseCode} does not run in {blockTypeTo}");
            }
            if (draggedOn.Course is not null && (BlockTypeFrom & draggedOn.Runtime) == 0)
            {
                ToastService.ShowToast(ToastLevel.Error, $"{draggedOn.Course.CourseCode} does not run in {BlockTypeFrom}");
            }
            if (State.CompletedTiles.Contains(DragPayload) && draggedOn.Course == null)
            {
                ToastService.ShowToast(ToastLevel.Error, "You cannot swap a completed course with a blank course.");
            }
            if (((blockTypeTo & DragPayload.Runtime) > 0 || DragPayload.Course == null) && ((BlockTypeFrom & draggedOn.Runtime) > 0 || draggedOn.Course == null))
            {
                Utilities.SwapValues(State.CourseData, DragPayload, draggedOn);
                draggedOn.ClearAllWarnings();
                DragPayload.ClearAllWarnings();


                await CheckPreceedingCourse(DragFrom, dragTo, DragPayload, draggedOn);
                await UpdateReliants(DragFrom, dragTo, DragPayload, draggedOn);
                if (dragTo != State.CompletedTiles)
                {
                    await ShowSwapWarnings(DragFrom, dragTo, DragPayload, draggedOn);
                }
                State.CompletedCourses = State.CompletedTiles.Select(c => c.Course).ToList();

                StateHasChanged();
            }
        }

        private async Task UpdateReliants(List<TileData> listFrom, List<TileData> listTo, TileData payload, TileData swapped)
        {
            foreach (Course course in await GetCorrectReliants(payload, State.CourseData.IndexOf(listTo), RequisiteType.AssumedKnowledge))
            {
                RemoveStatus(course, ErrorStatus.MissingAssumedKnowledge);
                FindTileData(course).ErrorData[ErrorStatus.MissingAssumedKnowledge].RemoveAll(c => c.CourseID == payload.Course.CourseID);
            }

            foreach (Course course in await GetCorrectReliants(payload, State.CourseData.IndexOf(listTo), RequisiteType.HardRequisite))
            {
                RemoveStatus(course, ErrorStatus.MissingPrerequisite);
                FindTileData(course).ErrorData[ErrorStatus.MissingPrerequisite].RemoveAll(c => c.CourseID == payload.Course.CourseID);
            }

            foreach (Course course in await GetCorrectReliants(payload, State.CourseData.IndexOf(listTo), RequisiteType.MustPreceed))
            {
                RemoveStatus(course, ErrorStatus.MissingSiblingCourse);
                FindTileData(course).ErrorData[ErrorStatus.MissingSiblingCourse].RemoveAll(c => c.CourseID == payload.Course.CourseID);
            }

            foreach (Course course in await GetCorrectReliants(swapped, State.CourseData.IndexOf(listTo), RequisiteType.AssumedKnowledge))
            {
                RemoveStatus(course, ErrorStatus.MissingAssumedKnowledge);
                FindTileData(course).ErrorData[ErrorStatus.MissingAssumedKnowledge].RemoveAll(c => c.CourseID == swapped.Course.CourseID);
            }

            foreach (Course course in await GetCorrectReliants(swapped, State.CourseData.IndexOf(listTo), RequisiteType.HardRequisite))
            {
                RemoveStatus(course, ErrorStatus.MissingPrerequisite);
                FindTileData(course).ErrorData[ErrorStatus.MissingPrerequisite].RemoveAll(c => c.CourseID == swapped.Course.CourseID);
            }

            foreach (Course course in await GetCorrectReliants(swapped, State.CourseData.IndexOf(listTo), RequisiteType.MustPreceed))
            {
                RemoveStatus(course, ErrorStatus.MissingSiblingCourse);
                FindTileData(course).ErrorData[ErrorStatus.MissingSiblingCourse].RemoveAll(c => c.CourseID == swapped.Course.CourseID);
            }
        }

        private async Task ShowSwapWarnings(List<TileData> listFrom, List<TileData> listTo, TileData payload, TileData swapped)
        {
            List<(int, int)> pairs = new List<(int, int)>();
            foreach (Course course in await GetMissingPrerequisites(payload, State.CourseData.IndexOf(listTo), RequisiteType.AssumedKnowledge))
            {
                ToastService.ShowToast(ToastLevel.Warning, $"{course.CourseCode} is assumed knowledge of {payload.Course.CourseCode}");
                payload.Status |= ErrorStatus.MissingAssumedKnowledge;
                payload.ErrorData[ErrorStatus.MissingAssumedKnowledge].Add(course);
                pairs.Add((course.CourseID, payload.Course.CourseID));
            }


            foreach (Course course in await GetMissingPrerequisites(payload, State.CourseData.IndexOf(listTo), RequisiteType.HardRequisite))
            {
                ToastService.ShowToast(ToastLevel.Error, $"{course.CourseCode} must be completed before {payload.Course.CourseCode}");
                payload.Status |= ErrorStatus.MissingPrerequisite;
                payload.ErrorData[ErrorStatus.MissingPrerequisite].Add(course);
                pairs.Add((course.CourseID, payload.Course.CourseID));
            }

            foreach (Course course in await GetMissingPrerequisites(payload, State.CourseData.IndexOf(listTo), RequisiteType.MustPreceed))
            {
                ToastService.ShowToast(ToastLevel.Error, $"{course.CourseCode} must be completed in the semester before {payload.Course.CourseCode}");
                payload.Status |= ErrorStatus.MissingSiblingCourse;
                payload.ErrorData[ErrorStatus.MissingSiblingCourse].Add(course);
                pairs.Add((course.CourseID, payload.Course.CourseID));
                SetStatus(course, ErrorStatus.MissingSiblingCourse);
            }



            foreach (Course course in await GetReliants(payload, State.CourseData.IndexOf(listTo), RequisiteType.AssumedKnowledge))
            {
                ToastService.ShowToast(ToastLevel.Warning, $"{payload.Course.CourseCode} is assumed knowledge of {course.CourseCode}");
                FindTileData(course).ErrorData[ErrorStatus.MissingAssumedKnowledge].Add(payload.Course);
                pairs.Add((payload.Course.CourseID, course.CourseID));
                SetStatus(course, ErrorStatus.MissingAssumedKnowledge);
            }


            foreach (Course course in await GetReliants(payload, State.CourseData.IndexOf(listTo), RequisiteType.HardRequisite))
            {
                ToastService.ShowToast(ToastLevel.Error, $"{payload.Course.CourseCode} must be completed before {course.CourseCode}");
                FindTileData(course).ErrorData[ErrorStatus.MissingPrerequisite].Add(payload.Course);
                pairs.Add((payload.Course.CourseID, course.CourseID));
                SetStatus(course, ErrorStatus.MissingPrerequisite);
            }



            foreach (Course course in await GetReliants(payload, State.CourseData.IndexOf(listTo), RequisiteType.MustPreceed))
            {
                ToastService.ShowToast(ToastLevel.Error, $"{payload.Course.CourseCode} must be completed in the semester before {course.CourseCode}");
                FindTileData(course).ErrorData[ErrorStatus.MissingSiblingCourse].Add(payload.Course);
                pairs.Add((payload.Course.CourseID, course.CourseID));
                payload.Status = ErrorStatus.MissingSiblingCourse;
                SetStatus(course, ErrorStatus.MissingSiblingCourse);
            }


            if (swapped != null)
            {
                foreach (Course course in await GetMissingPrerequisites(swapped, State.CourseData.IndexOf(listFrom), RequisiteType.AssumedKnowledge))
                {
                    if (!pairs.Any(p => p.Item1 == course.CourseID && p.Item2 == swapped.Course.CourseID))
                    {
                        ToastService.ShowToast(ToastLevel.Warning, $"{course.CourseCode} is assumed knowledge of {swapped.Course.CourseCode}");
                        swapped.ErrorData[ErrorStatus.MissingAssumedKnowledge].Add(course);
                    }

                    swapped.Status |= ErrorStatus.MissingAssumedKnowledge;
                }

                foreach (Course course in await GetMissingPrerequisites(swapped, State.CourseData.IndexOf(listFrom), RequisiteType.HardRequisite))
                {
                    if (!pairs.Any(p => p.Item1 == course.CourseID && p.Item2 == swapped.Course.CourseID))
                    {
                        ToastService.ShowToast(ToastLevel.Error, $"{course.CourseCode} must be completed before {swapped.Course.CourseCode}");
                        swapped.ErrorData[ErrorStatus.MissingPrerequisite].Add(course);
                    }

                    swapped.Status |= ErrorStatus.MissingPrerequisite;
                }

                foreach (Course course in await GetMissingPrerequisites(swapped, State.CourseData.IndexOf(listFrom), RequisiteType.MustPreceed))
                {
                    if (!pairs.Any(p => p.Item1 == course.CourseID && p.Item2 == swapped.Course.CourseID))
                    {
                        ToastService.ShowToast(ToastLevel.Error, $"{course.CourseCode} must be completed in the semester before {swapped.Course.CourseCode}");
                        swapped.ErrorData[ErrorStatus.MissingSiblingCourse].Add(course);
                    }
                    swapped.Status |= ErrorStatus.MissingSiblingCourse;
                    SetStatus(course, ErrorStatus.MissingSiblingCourse);
                }

                foreach (Course course in await GetReliants(swapped, State.CourseData.IndexOf(listFrom), RequisiteType.AssumedKnowledge))
                {
                    if (!pairs.Any(p => p.Item1 == swapped.Course.CourseID && p.Item2 == course.CourseID))
                    {
                        ToastService.ShowToast(ToastLevel.Warning, $"{swapped.Course.CourseCode} is assumed knowledge of {course.CourseCode}");
                        FindTileData(course).ErrorData[ErrorStatus.MissingAssumedKnowledge].Add(swapped.Course);
                    }

                    SetStatus(course, ErrorStatus.MissingAssumedKnowledge);

                }

                foreach (Course course in await GetReliants(swapped, State.CourseData.IndexOf(listFrom), RequisiteType.HardRequisite))
                {
                    if (!pairs.Any(p => p.Item1 == swapped.Course.CourseID && p.Item2 == course.CourseID))
                    {
                        ToastService.ShowToast(ToastLevel.Error, $"{swapped.Course.CourseCode} must be completed before {course.CourseCode}");
                        FindTileData(course).ErrorData[ErrorStatus.MissingPrerequisite].Add(swapped.Course);
                    }

                    SetStatus(course, ErrorStatus.MissingPrerequisite);
                }

                foreach (Course course in await GetReliants(swapped, State.CourseData.IndexOf(listFrom), RequisiteType.MustPreceed))
                {
                    if (!pairs.Any(p => p.Item1 == swapped.Course.CourseID && p.Item2 == course.CourseID))
                    {
                        ToastService.ShowToast(ToastLevel.Error, $"{swapped.Course.CourseCode} must be completed in the semester before {course.CourseCode}");
                        FindTileData(course).ErrorData[ErrorStatus.MissingSiblingCourse].Add(swapped.Course);
                    }

                    swapped.Status |= ErrorStatus.MissingSiblingCourse;
                    SetStatus(course, ErrorStatus.MissingSiblingCourse);
                }
            }
        }

        public async Task UpdateTileErrors(TileData td, List<TileData> slot)
        {
            foreach (Course course in await GetMissingPrerequisites(td, State.CourseData.IndexOf(slot), RequisiteType.AssumedKnowledge))
            {
                ToastService.ShowToast(ToastLevel.Warning, $"{course.CourseCode} is assumed knowledge of {td.Course.CourseCode}");
                td.Status |= ErrorStatus.MissingAssumedKnowledge;
            }

            foreach (Course course in await GetMissingPrerequisites(td, State.CourseData.IndexOf(slot), RequisiteType.HardRequisite))
            {
                ToastService.ShowToast(ToastLevel.Error, $"{course.CourseCode} must be completed before {td.Course.CourseCode}");
                td.Status |= ErrorStatus.MissingPrerequisite;
            }

            foreach (Course course in await GetMissingPrerequisites(td, State.CourseData.IndexOf(slot), RequisiteType.MustPreceed))
            {
                ToastService.ShowToast(ToastLevel.Error, $"{course.CourseCode} must be completed in the semester before {td.Course.CourseCode}");
                td.Status |= ErrorStatus.MissingSiblingCourse;
            }
        }

        public async Task CheckPreceedingCourse(List<TileData> listFrom, List<TileData> listTo, TileData payload, TileData swapped)
        {
            if (payload.Course != null)
            {
                var siblingCourses = await CourseService.GetPrerequisiteCoursesAsync(payload.Course.CourseID, RequisiteType.MustPreceed);
                foreach (Course course in siblingCourses)
                {
                    RemoveStatus(course, ErrorStatus.MissingSiblingCourse);
                }
            }

            if (swapped?.Course != null)
            {
                var siblingCourses = await CourseService.GetPrerequisiteCoursesAsync(swapped.Course.CourseID, RequisiteType.MustPreceed);
                foreach (Course course in siblingCourses)
                {
                    RemoveStatus(course, ErrorStatus.MissingSiblingCourse);
                }
            }
        }



        //Boolean to show the ghost tiles
        public bool ShowGhosts { get; set; } = false;
        //Show all ghost tiles in the plan
        public void ShowGhostTiles()
        {
            //Show a ghost tile in all places where the tile can be added
            ShowGhosts = true;
            StateHasChanged();
        }

        //Hide all ghost tiles in the plan
        public void HideGhostTiles()
        {
            //remove the ghost tiles
            ShowGhosts = false;
            StateHasChanged();
        }

        //Move payload from one slot to a new slot
        public async Task MovePayloadTo(List<TileData> slot)
        {
            //Made design decision to handle this hear, saves intensive cascading parameters.
            //Leaving this note here as I may decide to change later.
            slot.Add(DragPayload);
            DragFrom.Remove(DragPayload);

            DragPayload.ClearAllWarnings();



            FiftyUnitWarning(slot);

            await CheckPreceedingCourse(DragFrom, slot, DragPayload, null);
            await UpdateReliants(DragFrom, slot, DragPayload, null);
            if (slot != State.CompletedTiles)
            {

                await ShowSwapWarnings(DragFrom, slot, DragPayload, null);
            }
            State.CompletedCourses = State.CompletedTiles.Select(c => c.Course).ToList();
        }



        protected override async Task OnInitializedAsync()
        {
            Degree = State.Degree;
            Major = State.Major;
            Campus = State.Campus;

            if (Degree == null)
            {
                NavManager.NavigateTo("");
                return;
            }

            if (State.CourseData == null)
            {
                await ResetAsync(false);
            }

            isReady = true;
        }

        private async Task ResetAsync(bool resetCompletedCourses)
        {
            if (resetCompletedCourses)
            {
                State.CompletedCourses = new List<Course>();
            }

            State.CourseData = null;

            isReady = false;
            //Query database
            List<TileData> allCourseData = new List<TileData>();
            List<Course> coreCourses = (await DegreeCourseService.GetCoreCoursesAsync(State.Degree.DegreeID)).ToList();

            List<Course> completedCourseValidator = new List<Course>(State.CompletedCourses);
            int completedUnitCount = 0;

            State.CompletedTiles = new List<TileData>();

            //Loop through pulled courses
            foreach (Course course in coreCourses)
            {
                TileData td = new TileData()
                {
                    Course = course,
                    TileType = TileType.Core,
                    Runtime = await CourseService.GetCourseRuntimeAsync(course.CourseID, State.Campus)
                };

                int counter = completedCourseValidator.RemoveAll(c => c.CourseID == course.CourseID);
                if (counter > 0)
                {
                    State.CompletedTiles.Add(td);
                    completedUnitCount += counter;
                }
                else
                {
                    allCourseData.Add(td);
                }
            }

            var coreDirectedCourses = await MajorCourseService.GetCompulsoryCoursesAsync(State.Major.MajorID);
            //Pull directed courses
            foreach (Course course in coreDirectedCourses)
            {
                TileData td = new TileData()
                {
                    Course = course,
                    TileType = TileType.Compulsory,
                    Runtime = await CourseService.GetCourseRuntimeAsync(course.CourseID, State.Campus)
                };

                int counter = completedCourseValidator.RemoveAll(c => c.CourseID == course.CourseID);
                if (counter > 0)
                {
                    State.CompletedTiles.Add(td);
                    completedUnitCount += counter;
                }
                else
                {
                    allCourseData.Add(td);
                }
            }

            List<TileData> tempCache = new List<TileData>();


            //Create all empty directed
            int directedUnits = State.Degree.UnitLength - allCourseData.Sum(t => t.Course.Units) - State.CompletedTiles.Sum(t => t.Course.Units) - State.Degree.ElectiveUnits;
            if (completedCourseValidator.Count > 0)
            {
                var nonCompulsoryCourses = await MajorCourseService.GetNonCompulsoryCoursesAsync(State.Major.MajorID);
                var courses = completedCourseValidator.Where(c => nonCompulsoryCourses.Any(n => n.CourseID == c.CourseID));
                if (courses.Count() > 0 && courses.Sum(t => t.Units) < directedUnits)
                {
                    foreach (Course c in courses)
                    {
                        TileData td = new TileData()
                        {
                            Course = c,
                            TileType = TileType.Directed,
                            Runtime = await CourseService.GetCourseRuntimeAsync(c.CourseID, State.Campus)
                        };
                        State.CompletedTiles.Add(td);
                    }
                    directedUnits -= courses.Sum(t => t.Units);
                    completedCourseValidator.RemoveAll(c => courses.Any(comp => comp.CourseID == c.CourseID));

                }
                else if (courses.Count() > 0)
                {
                    var tempCourses = new List<Course>();
                    int i = 0;
                    while (tempCourses.Sum(t => t.Units) < directedUnits)
                    {
                        tempCourses.Add(courses.ElementAt(i++));
                    }
                    foreach (Course c in tempCourses)
                    {
                        TileData td = new TileData()
                        {
                            Course = c,
                            TileType = TileType.Directed,
                            Runtime = await CourseService.GetCourseRuntimeAsync(c.CourseID, State.Campus)
                        };
                        State.CompletedTiles.Add(td);
                        completedCourseValidator.Remove(c);
                    }
                    directedUnits = 0;
                }

                foreach (Course c in completedCourseValidator)
                {
                    TileData td = new TileData()
                    {
                        Course = c,
                        TileType = TileType.Elective,
                        Runtime = await CourseService.GetCourseRuntimeAsync(c.CourseID, State.Campus)
                    };
                    State.CompletedTiles.Add(td);
                }
            }

            for (int i = 0; i < directedUnits; i += 10)
            {
                TileData td = new TileData()
                {
                    Course = null,
                    TileType = TileType.Directed
                };
                tempCache.Add(td);
            }

            //Create all empty elective courses
            // Add excess for the number of completed courses
            for (int i = 0; i < State.Degree.ElectiveUnits - completedCourseValidator.Sum(c => c.Units) + State.CompletedCourses.Sum(c => c.Units); i += 10)
            {
                TileData td = new TileData()
                {
                    Course = null,
                    TileType = TileType.Elective
                };
                tempCache.Add(td);
            }

            //Add them to plan
            allCourseData.AddRange(tempCache);

            List<TileData> cache = allCourseData.OrderBy(c => c.Course?.CourseCode[4..] ?? "9999").ToList();

            output = SetupStructure(State.RuntimeStart == CourseRuntime.Semester2);

            int n = State.RuntimeStart == CourseRuntime.Semester2 ? 1 : 0;

            states = new List<int>();

            if (await Autocomplete(cache, n))
            {
                for (int i = 0; i < output.Count; i++)
                {
                    output[i] = output[i].OrderBy(c => c.Course?.CourseCode ?? "ZZZZ9999").ToList();
                }

                int total = State.CompletedCourses.Count;

                output.Reverse();
                foreach (List<TileData> tiles in output)
                {
                    if (total == 0)
                        break;
                    for (int i = tiles.Count - 1; i >= 0; i--)
                    {
                        if (total == 0)
                            break;
                        if (tiles[i].TileType == TileType.Elective)
                        {
                            tiles.RemoveAt(i);
                            total--;
                        }
                    }
                }

                output.Reverse();

                State.CourseData = output;
            }
            else
            {
                // Throw toast error
            }

            //Parameters set, modify as needed
            isReady = true;
        }

        //Returns all courses in the plan
        public IEnumerable<Course> getAllCourses()
        {
            IEnumerable<Course> allC = new List<Course>();

            foreach (List<TileData> sem in State.CourseData)
            {
                foreach (TileData td in sem)
                {
                    allC.Append(td.Course);
                }
            }

            return allC;
        }

        public void FiftyUnitWarning(List<TileData> slot)
        {
            if (slot.Sum(c => c.Course?.Units ?? 10) == 50 && !fiftyUnitsWarningBool) //Change 50 to readonly total in later branch.
            {
                RenderFragment message = b =>
                {
                    b.AddContent(0, "By including 50 units in a semester, you will have to go to the UON website and follow instructions in order to enrol in 50 units. Find it ");
                    b.OpenElement(1, "a");
                    b.AddAttribute(2, "href", "https://askuon.newcastle.edu.au/app/answers/detail/a_id/1764/~/can-i-enrol-in-more-than-40-units-in-a-semester%3F");
                    b.AddAttribute(3, "target", "_blank");
                    b.AddContent(4, "here");
                    b.CloseElement();
                };
                ToastService.ShowToast(ToastLevel.Warning, message);
                fiftyUnitsWarningBool = true;
            }

        }
        //Returns true if the plan contains the course
        public bool ContainsCourse(Course course)
        {
            return State.CourseData.Any(sem => sem.Any(c => (c.Course?.CourseID ?? -1) == course.CourseID));
        }

        private List<List<TileData>> SetupStructure(bool sem2Start)
        {
            int yearCount = State.Degree.UnitLength / (State.UnitsPerBlock * State.BlocksPerYear);
            if (sem2Start)
                yearCount++;


            List<List<TileData>> toReturn = new List<List<TileData>>();

            for (int i = 0; i < yearCount; i++)
            {
                toReturn.Add(new List<TileData>());
                toReturn.Add(new List<TileData>());
            }

            return toReturn;
        }


        private List<List<TileData>> output;

        /// <summary>
        /// THE MAIN ALGORITHM
        /// </summary>
        private async Task<bool> Autocomplete(List<TileData> cache, int n)
        {
            if (cache.Count == 0)
                return true;

            int index = 0;
            bool flag = false;
            do
            {
                TileData td = cache[index++];
                if (output[n].Sum(c => c.Course?.Units ?? 10) >= State.UnitsPerBlock)
                    n++;

                if (n >= State.Degree.UnitLength / State.UnitsPerBlock + (State.RuntimeStart == CourseRuntime.Semester2 ? 1 : 0))
                    return false;

                while (!await ValidateCourse(td, n))
                {
                    if (index == cache.Count)
                        return false;
                    td = cache[index++];
                }

                DisplayOutput();
                output[n].Add(td);
                if (StateHasAppeared())
                {
                    output[n].Remove(td);
                }
                else
                {
                    cache.RemoveAt(index - 1);
                    flag = await Autocomplete(new List<TileData>(cache), n);
                    if (!flag)
                    {
                        output[n].Remove(td);
                    }
                    cache.Insert(index - 1, td);
                }
            }
            while (!flag && index < cache.Count);

            return flag;
        }

        private async Task<bool> ValidateCourse(TileData td, int n)
        {
            bool flag = true;

            int sum = output.Sum(i => i.Count) + State.CompletedTiles.Count;
            double groupNumber = sum / 8.0 + 0.5;
            //double groupNumber = (n - (State.RuntimeStart == CourseRuntime.Semester2 ? 1 : 0)) / 2.0 + 1.5 + State.CompletedTiles.Count / 8.0;

            int minDirectedGroup = int.Parse((await MajorCourseService.GetNonCompulsoryCoursesAsync(State.Major.MajorID)).ToList().Min(c => c.CourseCode[4]).ToString());

            if (td.Course == null)
            {
                if (td.TileType == TileType.Directed && minDirectedGroup <= groupNumber + 0.5)
                    return true;
                else if (td.TileType == TileType.Elective)
                    return true;
                else
                    return false;
            }

            if (n % 2 == 0 && (td.Runtime & CourseRuntime.Semester1) == 0)
                flag = false;
            else if (n % 2 == 1 && (td.Runtime & CourseRuntime.Semester2) == 0)
                flag = false;
            else if (!await CheckSiblingCourse(td, n))
                flag = false;
            else if (int.Parse(td.Course.CourseCode[4].ToString()) > groupNumber + 1)
                flag = false;
            else if (!await CheckPrerequisites(td, n))
                flag = false;
            else if (output.Sum(s => s.Sum(c => c.Course?.Units ?? 10)) + State.CompletedCourses.Sum(c => c.Units) < td.Course.RequiredCompletedUnits)
                flag = false;

            return flag;
        }

        private void DisplayOutput()
        {
            int n = 0;
            foreach (List<TileData> block in output)
            {
                Console.Write("|");
                foreach (TileData td in block)
                {
                    Console.Write(" ");
                    Console.Write(td.Course?.CourseCode ?? "Blank");
                    Console.Write(" ");
                }
                Console.Write("|");
                if (n++ % 2 == 1)
                    Console.WriteLine();
            }
        }

        private List<int> states = new List<int>();
        private bool StateHasAppeared()
        {
            int hash = EncodeOutput();
            if (states.Contains(hash))
                return true;
            states.Add(hash);
            return false;
        }

        private int EncodeOutput()
        {
            string hashStr = "";
            foreach (List<TileData> block in output)
            {
                foreach (TileData td in block.OrderBy(c => c.Course?.CourseCode ?? "9999"))
                {
                    if (td.Course != null)
                    {
                        hashStr += td.Course.CourseCode;
                    }
                    else
                    {
                        hashStr += "BLANK";
                    }
                }
            }
            return hashStr.GetHashCode();
        }

        private async Task<bool> CheckPrerequisites(TileData tile, int n)
        {
            if (tile.Course == null)
                return true;

            var courseIDList = (await CourseService.GetPrerequisiteCoursesAsync(tile.Course.CourseID)).ToList();

            int tally = 0;
            //var list = await CourseService.GetCoursesAsync(courseIDList.Select(c => c.PrerequisiteCourseID));
            for (int i = 0; i < n; i++)
            {

                tally += courseIDList.Count(c => output[i].Any(t => t.Course?.CourseID == c.CourseID));
            }

            tally += courseIDList.Count(c => State.CompletedCourses.Any(completedCourse => completedCourse.CourseID == c.CourseID));

            return tally == courseIDList.Count();
        }

        private async Task<bool> CheckSiblingCourse(TileData tile, int n)
        {
            if (n == 0)
                return true;

            var courseIDList = await CourseService.GetPrerequisiteCoursesAsync(tile.Course.CourseID, RequisiteType.MustPreceed);

            foreach (Course course in courseIDList)
            {
                if (!output[n - 1].Any(c => (c.Course?.CourseCode ?? "lmfao") == course.CourseCode))
                {
                    return false;
                }
            }
            return true;
        }

        private async Task<List<Course>> GetMissingPrerequisites(TileData tile, int n, RequisiteType requisite)
        {
            if (tile.Course == null)
                return new List<Course>();

            var courseList = (await CourseService.GetPrerequisiteCoursesAsync(tile.Course.CourseID, requisite)).ToList();

            courseList.RemoveAll(c => State.CompletedTiles.Any(completedCourse => completedCourse.Course.CourseID == c.CourseID));

            if (requisite == RequisiteType.MustPreceed && n > 0)
            {
                courseList.RemoveAll(c => State.CourseData[n - 1].Any(t => t.Course?.CourseID == c.CourseID));
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    courseList.RemoveAll(c => State.CourseData[i].Any(t => t.Course?.CourseID == c.CourseID));
                }
            }

            return courseList;
        }

        private async Task<List<Course>> GetReliants(TileData tile, int n, RequisiteType requisite)
        {
            if (tile.Course == null)
                return new List<Course>();

            var courseList = (await CourseService.GetReliantCoursesAsync(tile.Course.CourseID, requisite)).ToList();

            courseList.RemoveAll(c => State.CompletedTiles.Any(completedCourse => completedCourse.Course.CourseID == c.CourseID));
            courseList.RemoveAll(c => FindTileData(c) == null);

            if (n == State.CourseData.Count - 1)
                return courseList;

            if (requisite == RequisiteType.MustPreceed)
            {
                courseList.RemoveAll(c => State.CourseData[n + 1].Any(t => t.Course?.CourseID == c.CourseID));
            }
            else
            {
                courseList.RemoveAll(c => !State.CourseData.Take(n + 1).Any(s => s.Any(t => t.Course?.CourseID == c.CourseID)));
            }

            return courseList;
        }


        private async Task<List<Course>> GetCorrectReliants(TileData tile, int n, RequisiteType requisite)
        {
            if (tile?.Course == null || n == State.CourseData.Count - 1)
                return new List<Course>();

            var courseList = (await CourseService.GetReliantCoursesAsync(tile.Course.CourseID, requisite)).ToList();

            courseList.RemoveAll(c => State.CompletedTiles.Any(completedCourse => completedCourse.Course.CourseID == c.CourseID));
            courseList.RemoveAll(c => !ContainsCourse(c));

            if (requisite == RequisiteType.MustPreceed)
            {
                courseList.RemoveAll(c => !State.CourseData[n + 1].Any(t => t.Course?.CourseID == c.CourseID));
            }
            else
            {
                courseList.RemoveAll(c => State.CourseData.Take(n + 1).Any(s => s.Any(t => t.Course?.CourseID == c.CourseID && t.Status == 0)));
            }

            return courseList;
        }
        private void SetErrorData(TileData td, List<Course> errors, ErrorStatus error)
        {
            if (errors.Count != 0)
            {
                td.ErrorData.Add(error, errors);
                errors.Clear();
            }

        }
        private void SetStatus(Course course, ErrorStatus status)
        {
            foreach (var slot in State.CourseData)
            {
                foreach (var td in slot)
                {
                    if (td.Course == null) continue;
                    if (td.Course.CourseID == course.CourseID)
                    {
                        td.Status = status;
                        return;
                    }
                }
            }
        }

        private TileData FindTileData(Course course)
        {
            foreach (var slot in State.CourseData)
            {
                foreach (var td in slot)
                {
                    if (td.Course == null) continue;
                    if (td.Course.CourseID == course.CourseID)
                    {
                        return td;
                    }
                }
            }
            return null;
        }

        private void RemoveStatus(Course course, ErrorStatus status)
        {
            foreach (var slot in State.CourseData)
            {
                foreach (var td in slot)
                {
                    if (td.Course == null) continue;
                    if (td.Course.CourseID == course.CourseID && (td.Status & status) > 0)
                    {
                        td.Status ^= td.Status & status;
                        return;
                    }
                }
            }
        }

        public String GetAllSiblingErrors()
        {
            errors = "";
            foreach (var semester in State.CourseData)
            {
                foreach (var tileData in semester)
                {
                    errors += tileData.GetSiblingErrors();
                }
            }
            return errors;
        }

        public String GetAllPrereqErrors()
        {
            errors = "";
            foreach (var semester in State.CourseData)
            {
                foreach (var tileData in semester)
                {
                    errors += tileData.GetPreReqErrors();
                }
            }
            return errors;
        }

        public String GetAllPrereqWarnings()
        {
            errors = "";
            foreach (var semester in State.CourseData)
            {
                foreach (var tileData in semester)
                {
                    errors += tileData.GetPreReqWarnings();
                }
            }
            return warnings;
        }

        private void AddYear()
        {
            State.CourseData.Add(new List<TileData>());
            State.CourseData.Add(new List<TileData>());
            StateHasChanged();
        }

        private void RemoveYear()
        {
            //----------------------------------------
            //Count the total number of rows(semester tiles)
            //Check if total tiles is greater than 1
            //Remove the last index from the total tile
            //----------------------------------------

            if (State.CourseData.Count >= 2)
            {
                if (State.CourseData[^1].Count == 0 && State.CourseData[^2].Count == 0)

                {
                    State.CourseData.RemoveAt(State.CourseData.Count - 1);
                    State.CourseData.RemoveAt(State.CourseData.Count - 1);
                }


            }

            StateHasChanged(); //Will update in all the components
        }
    }
}