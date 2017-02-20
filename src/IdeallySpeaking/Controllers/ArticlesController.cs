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

namespace IdeallySpeaking.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;        

        public ArticlesController(ApplicationDbContext context)
        {
            _context = context;            
        }

        // GET: Articles
        public async Task<IActionResult> Index(string searchString)
        {
            var articles = from a in _context.Articles
                           select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                articles = articles.Where(s => s.Headline.Contains(searchString));
            }
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
                //.Include(a => a.CommentList)
                //Including due to its being a 'List' or 'Collection'
                .SingleOrDefaultAsync(m => m.ArticleId == id);
            /*if (article == null)
            {
                return NotFound();
            }*/            

            return View(article);
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
        public async Task<IActionResult> Create([Bind("ArticleId,Headline,Content,Teaser,Date,AuthorUserId")] Article article)
        {
            if (ModelState.IsValid)
            {
                _context.Add(article);                
                await _context.SaveChangesAsync();

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
        public async Task<IActionResult> Edit(int id, [Bind("ArticleId,Headline,Content,Teaser,Date,AuthorUserId")] Article article)
        {
            if (id != article.ArticleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
                return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleId == id);
        }
        
    }
}


