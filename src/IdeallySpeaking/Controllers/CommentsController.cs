using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdeallySpeaking.Data;
using IdeallySpeaking.Models;
using System.ComponentModel.DataAnnotations;
using static IdeallySpeaking.Models.CommentViewModels.CommentsRatingViewModel;

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
        [Route("ArticleComments")]
        public async Task<IActionResult> IndexPartial(int id)
        {
            var applicationDbContext = _context.Comments.Where(c => c.ArticleId == id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Comments/SingleComment/5
        [Display(Name = "Comment")]
        public async Task<IActionResult> SingleCommentPartial(int? id)
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
        [ActionName("Create")]
        public async Task<IActionResult> CreatePartial([Bind("CommentId,CommentDate,Title,CommentContent,ArticleId,ApplicationUserId,Rating")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.Rating = new CommentsRating() { };
                _context.Add(comment);
                await _context.SaveChangesAsync();

                ViewBag["CurrentArticleId"] = comment.ArticleId;                

                return RedirectToAction("IndexPartial", ViewBag["CurrentArticleId"]);
            }
            return PartialView(comment);
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
                    ViewBag["CurrentArticleId"] = comment.ArticleId;
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
                return RedirectToAction("IndexPartial", ViewBag["CurrentArticleId"]);
            }            
            return View(comment);
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
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
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _context.Comments.SingleOrDefaultAsync(m => m.CommentId == id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            ViewBag["CurrentArticleId"] = comment.ArticleId;
            return RedirectToAction("IndexPartial", ViewBag["CurrentArticleId"]);
        }

        // GET: Comments/PopularCommentsList/5        
        public async Task<IActionResult> PopularCommentsList(int num)
        {
            var items = await GetPopularItemsAsync(num);
            return View(items); 
        }

        private async Task<List<Comment>> GetPopularItemsAsync(int num)
        {
            IQueryable<Comment> comments = from c in _context.Comments
            .OrderByDescending(r => r.Rating).Take(num)
                                           select c;
            return await comments.ToListAsync();
        }

        // GET: Comments/UserCommentsList/1001        
        public async Task<IActionResult> UserCommentsList(int id)
        {
            var userComments = await GetUserCommentsAsync(id);
            return View(userComments);
        }
        private async Task<List<Comment>> GetUserCommentsAsync(int id)
        {
            IQueryable<Comment> comments = from c in _context.Comments
                                           .Where(u => u.ApplicationUserId == id)
                                           select c;

            return await comments.ToListAsync();
        }

        // GET: Comment/Reply/?
        public async Task<IActionResult> Reply(int? id)
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

            return View();
        }

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

                ViewBag["CurrentArticleId"] = reply.ArticleId;

                return RedirectToAction("IndexPartial", ViewBag["CurrentArticleId"]);
            }
            return PartialView(reply);

        }



        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }

        /* As a Matter of Interest
         * 
         * Code for a Default Select-List:
         * ViewData["ArticleId"] = new SelectList(_context.Articles, "ArticleId", "ArticleId", comment.ArticleId);
         * 
         * Researching the Below HTMLHelperPartialExtension
         * public static Task<IHtmlContent> PartialAsync(this IHtmlHelper htmlHelper, string partialViewName, object model);
         * 
         * Decided Against Using This Method in 'CreatePartial'
         * var id = comment.CommentId;
         * var returnUrl = "http://ideallyspeaking.net/articles/fullarticle/" + id;
         */
    }
}
