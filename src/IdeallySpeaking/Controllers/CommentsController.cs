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

        // GET: Comments/id
        // All Comments for an Article w/ArticleId = id
        // For Display w/"Index" PartialView @ FullArticle
        [Route("ArticleComments")]
        public async Task<IActionResult> IndexPartial(int id)
        {
            var items = await GetAllCommentsAsync(id);
            return PartialView(items);
        }
        private async Task<List<Comment>> GetAllCommentsAsync(int id)
        {
            IQueryable<Comment> comments = from c in _context.ApplicationUser
                                           .Include(i => i.ArticleId == id)
                                           select c;

            return await comments.ToListAsync();
        }

        // GET: Comments/SingleComment/id
        // Single Comment for an Article w/Current CommentId
        // SingleCommentPartial 
        public async Task<IActionResult> SingleComment(int id)
        {
            /*if (id == null)
            {
                return NotFound();
            }*/
            var comment = await _context.ApplicationUser
                .SingleOrDefaultAsync(c => c.CommentId == id);
            /*if (comment == null)
            {
                return NotFound();
            }*/
            ViewData["Request"] = "GET";

            return View(comment);
        }

        // POST: Comments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("CreatePartial")]
        public async Task<IActionResult> Create([Bind("CommentId, CommentDate, Title, CommentContent,ArticleId, ApplicationUserId, Rating")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comment);

                await _context.SaveChangesAsync();

                var id = comment.CommentId;
                var returnUrl = "http://ideallyspeaking.net/articles/fullarticle/" + id;

                return Redirect(returnUrl);
            }
            return PartialView("CreatePartial");
        } 

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.CommentId == id);
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

            var reply = await _context.ApplicationUser
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
        public async Task<IActionResult> Reply([Bind("CommentId, CommentDate, Title, CommentContent,ArticleId, ApplicationUserId, Rating")] Comment reply)
        {
            if (ModelState.IsValid)
            {
                _context.ApplicationUser.Add(reply);
                //_context.UsersComments(user).Add(reply);
                await _context.SaveChangesAsync();
                return RedirectToAction("Reply");
            }
            return PartialView(reply);
            
        }

        // Researching the Below HTMLHelperPartialExtension
        // public static Task<IHtmlContent> PartialAsync(this IHtmlHelper htmlHelper, string partialViewName, object model);

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.ApplicationUser
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
            var comment = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.CommentId == id);
            _context.ApplicationUser.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }        

        // GET: Comments/PopularCommentsList/5
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PopularCommentsList(int num)
        {
            var items = await GetPopularItemsAsync(num);
            return View(items); //
        }

        private async Task<List<Comment>> GetPopularItemsAsync(int num)
        {             
            IQueryable<Comment> comments = from c in _context.ApplicationUser
            .OrderByDescending(r => r.Rating).Take(num)
                                           select c;            
            return await comments.ToListAsync();
        }

        private bool CommentExists(int id)
        {
            return _context.ApplicationUser.Any(e => e.CommentId == id);
        }

    }
}
