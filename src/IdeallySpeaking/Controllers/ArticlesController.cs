using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdeallySpeaking.Data;
using IdeallySpeaking.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace IdeallySpeaking.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private UserTextInput _input;

        public ArticlesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Articles/Search
        public async Task<IActionResult> Search(string searchString)
        {
            var articles = from a in _context.Articles
                           select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                articles = articles.Where(s => s.Headline.Contains(searchString));
            }
            List<Article> art = await _context.Articles.ToListAsync();
            
            return View(await _context.Articles.ToListAsync());
        }

        // GET: Articles/FullArticle/5
        public async Task<IActionResult> FullArticle(int? id)
        {
            /*if (id == null)
            {
                return NotFound();
            }*/

            var article = await _context.Articles                
                .SingleOrDefaultAsync(m => m.ArticleId == id);
            /*if (article == null)
            {
                return NotFound();
            }*/            

            return View(article);
        }

        // GET: Event/Details/5
        public async Task<IActionResult> ArticleDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var details = await _context.Articles
                .SingleOrDefaultAsync(m => m.ArticleId == id);
            if (details == null)
            {
                return NotFound();
            }

            return View(details);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Headline, Content, Teaser, Date, Author")] Article article)
        {
            if (ModelState.IsValid)
            {
                var tease = article.Teaser;
                _context.Entry(article).Property("Teaser").CurrentValue = tease;
                article.Author = await GetCurrentUserAsync();
                
                _context.Add(article);
                
                await _context.SaveChangesAsync();
                //ViewData["CurrentReader"] = GetCurrentUserAsync();
                return RedirectToAction("FullArticle");                
            }
            
            return View(article);
        }        

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.SingleOrDefaultAsync(m => m.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Headline,Content,Teaser,Date")] Article article)
        {
            if (id != article.ArticleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var tease = article.Teaser;
                    _context.Entry(article).Property("Teaser").CurrentValue = tease;
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.ArticleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(FullArticle), "Articles");
            }
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .SingleOrDefaultAsync(m => m.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Articles.SingleOrDefaultAsync(m => m.ArticleId == id);
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return View(nameof(HomeController), "Index");
        }

        // POST: Articles/ArticlePhoto
        [HttpPost]
        public async Task<IActionResult> ArticlePhoto(IFormFile file)
        {
            var filePath = Path.GetTempFileName();
            var article = new Article();

            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            await _context.SaveChangesAsync();

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                article.ArticlePhoto = memoryStream.ToArray();
            }

            return View();
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleId == id);
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

    }
}


