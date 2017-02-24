using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdeallySpeaking.Data;
using IdeallySpeaking.Models;
using IdeallySpeaking.Models.CommentViewModels;
using Microsoft.AspNetCore.Identity;

namespace IdeallySpeaking.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _context;                

        public CommentsController(ApplicationDbContext context)
        {
            _context = context;            
        }

        // GET: Comments
        // NO VIEW - Store in ArticleCommentList
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comment.ToListAsync());
        }

        // GET: Comments/ArticleComment/5
        public async Task<IActionResult> ArticleComment(int id)
        {
            /*if (id == null)
            {
                return NotFound();
            }*/

            var comments = await _context.Comment.ToListAsync();
            /* (m => m.ArticleId == id); */
            /* var artId = id; Comment.ArticleId = artId */
            /*if (comment == null)
            {
                return NotFound();
            }*/

            return View(comments);
        }

        // GET: Comments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,CommentDate,Title,CommentContent,ArticleId,ApplicationUserId,Rating")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comment);                                
                //_context.ArticleCommentsList(article).Add(comment);
                // Next: Add comment to UserCommentsList
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comment.SingleOrDefaultAsync(m => m.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentId,CommentDate,Title,CommentContent,ArticleId,ApplicationUserId,Rating")] Comment comment)
        {
            if (id != comment.CommentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.CommentId))
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
            return View(comment);
        }

        // GET: Comment/Reply/?
        public async Task<IActionResult> Reply(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reply = await _context.Comment
                .SingleOrDefaultAsync(m => m.CommentId == id);
            if (reply == null)
            {
                return NotFound();
            }

            return View(reply);
        }

        // POST: Comment/Reply/?
        [HttpPost, ActionName("Post Reply")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostReply(int? id)
        {
            var reply = await _context.Comment.SingleOrDefaultAsync(m => m.CommentId == id);
            _context.Comment.Add(reply);
            //_context.UsersComments(user).Add(reply);
            await _context.SaveChangesAsync();
            return RedirectToAction("Reply");
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comment
                .SingleOrDefaultAsync(m => m.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _context.Comment.SingleOrDefaultAsync(m => m.CommentId == id);
            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Comments/PopularCommentsList/5
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PopularCommentsList(int num)
        {
            var items = await GetItemsAsync(num);
            return View(items); //
        }

        private async Task<List<Comment>> GetItemsAsync(int num)
        {             
            IQueryable<Comment> comments = from c in _context.Comment
            .OrderByDescending(r => r.Rating).Take(num)
                                           select c;            
            return await comments.ToListAsync();
        }

        private bool CommentExists(int id)
        {
            return _context.Comment.Any(e => e.CommentId == id);
        }

    }
}
