﻿using Microsoft.AspNetCore.Mvc;

namespace _20240829_EmptyBootstrap.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
