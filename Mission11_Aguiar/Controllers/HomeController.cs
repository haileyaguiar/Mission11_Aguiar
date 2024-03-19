using Microsoft.AspNetCore.Mvc;
using Mission11_Aguiar.Models;
using Mission11_Aguiar.Models.ViewModels;
using System.Diagnostics;

namespace Mission11_Aguiar.Controllers
{
    public class HomeController : Controller
    {

        private IBookRepository _bookRepository;

        public HomeController(IBookRepository temp)
        {
            _bookRepository = temp;
            
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 5;

            var blah = new BooksListViewModel
            {
                Books = _bookRepository.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _bookRepository.Books.Count()
                }
            };

            return View(blah);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
