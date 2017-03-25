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
using static IdeallySpeaking.Models.CommentViewModels.CommentsRatingViewModel;

namespace IdeallySpeaking.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _context;        

        public CommentController(ApplicationDbContext context)
        {
            _context = context;            
        }

        // GET: Comments/SingleComment/id
        // Single Comment for an Article w/Current CommentId
        // SingleCommentPartial 
       /* public async Task<IActionResult> SingleComment(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var comment = await _context.Comments
                .SingleOrDefaultAsync(c => c.CommentId == id);
             (comment == null)
            {
                return NotFound();
            /
            ViewData["Request"] = "GET";

            return View(comment);
        } */

        // POST: Comments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<IActionResult> CreatePartial([Bind("CommentId, CommentDate, Title, CommentContent,ArticleId, ApplicationUserId, Rating")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.Rating = new CommentsRating(){ };
                _context.Add(comment);

                await _context.SaveChangesAsync();

                var id = comment.CommentId;
                var returnUrl = "http://ideallyspeaking.net/articles/fullarticle/" + id;

                return Redirect(returnUrl);
            }
            return PartialView();
        } 

        // GET: Comments/Edit/5
       /* public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments.SingleOrDefaultAsync(m => m.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        } */

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
                return RedirectToAction("IndexPartial");
            }
            return View(comment);
        }

        // GET: Comment/Reply/?
       /* public async Task<IActionResult> Reply(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reply = await _context.Comments
                .SingleOrDefaultAsync(m => m.CommentId == id);
            if (reply == null)
            {
                return NotFound();
            }

            return View(reply);
        } */

        // POST: Comment/Reply/?
        [HttpPost, ActionName("Post Reply")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reply([Bind("CommentId, CommentDate, Title, CommentContent,ArticleId, ApplicationUserId, Rating")] Comment reply)
        {
            if (ModelState.IsValid)
            {
                reply.Rating = new CommentsRating() { };
                _context.Add(reply);

                await _context.SaveChangesAsync();
                return RedirectToAction("Reply");
            }
            return PartialView(reply);
            
        }

        // Researching the Below HTMLHelperPartialExtension
        // public static Task<IHtmlContent> PartialAsync(this IHtmlHelper htmlHelper, string partialViewName, object model);

        // GET: Comments/Delete/5
       /* public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .SingleOrDefaultAsync(m => m.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        } */

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        /*public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _context.Comments.SingleOrDefaultAsync(m => m.CommentId == id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction("IndexPartial");
        }*/

        // GET: Comments/PopularCommentsList/5        
        /* public async Task<IActionResult> PopularCommentsList(int num)
         {
             var items = await GetPopularItemsAsync(num);
             return View(items); //
         }

         private async Task<List<Comment>> GetPopularItemsAsync(int num)
         {             
             IQueryable<Comment> comments = from c in _context.Comments
             .OrderByDescending(r => r.Rating).Take(num)
                                            select c;            
             return await comments.ToListAsync();
         } */

        /*  NEED: Populate UserCommentsList Method  */

        // GET: Comments/PopularCommentsList/5        
        /* public async Task<IActionResult> UserCommentsList(int id)
         * {
         *   var userComments = await GetUserCommentsAsync(id)
         *   return View(userComments);
         * }

         private async Task<List<Comment>> GetUserCommentsAsync(int id)
         {
             IQueryable<Comment> comments = from c in _context.Comments
                                            .Include(u => u.ApplicationUserId == id)
                                            select c;

             return await comments.ToListAsync();
         } */

         // Helper Methods
         private bool CommentExists(int id)
         {
             return _context.ApplicationUser.Any(e => e.CommentId == id);
         }
    }
}
