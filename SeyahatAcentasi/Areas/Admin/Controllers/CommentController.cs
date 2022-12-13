using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace SeyahatAcentasi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()   //tablo verilerini olusturmak icin
        {
            var values = _commentService.GetListCommentWithDestination();  //tanımlanan _commentservice'den fonksiyon degerleri dondurur values'e atar 
            return View(values);
        }

        public IActionResult DeleteComment(int id)    //yorum silme fonksiyonu
        {
            var values = _commentService.GetTByID(id);   //yorum servisinden id sine'gore getir 
            _commentService.TDelete(values);            //gelen degeri sil
            return RedirectToAction("Index");           //Index'e yonlendir
                
        }
    }
}
