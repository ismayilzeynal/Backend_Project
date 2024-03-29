﻿using BackendProject.DAL;
using BackendProject.ViewModels.Teacher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public TeacherController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            List<TeacherVM> teacherVMs = new();
            var TeacherList = _appDbContext.Teachers
                .Include(t => t.Contacts)
                .ToList();
            foreach (var teacher in TeacherList)
            {
                TeacherVM teacherVM = new();
                teacherVM.Id = teacher.Id;
                teacherVM.FullName = teacher.FullName;
                teacherVM.Title = teacher.Title;
                teacherVM.ImageUrl = teacher.ImageUrl;
                teacherVM.Facebook = teacher.Contacts.Facebook;
                teacherVM.Vimeo = teacher.Contacts.Vimeo;
                teacherVM.Pinterest = teacher.Contacts.Pinterest;
                teacherVM.Twitter = teacher.Contacts.Twitter;
                teacherVMs.Add(teacherVM);
            }
            return View(teacherVMs);
        }

        [Authorize]
        public IActionResult Detail(int id)
        {
            if (id == null) return NotFound();

            TeacherDetailVM teacherDetailVM = new();
            teacherDetailVM.Teacher = _appDbContext.Teachers.FirstOrDefault(t => t.Id == id);
            teacherDetailVM.Contacts = _appDbContext.Contacts.FirstOrDefault(c => c.TeacherId == id);
            teacherDetailVM.Skills = _appDbContext.Skills.Where(s => s.TeacherId == id).ToList();
            if (teacherDetailVM.Teacher == null) return NotFound();

            return View(teacherDetailVM);
        }
    }
}
