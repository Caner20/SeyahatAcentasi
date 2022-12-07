﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SeyahatAcentasi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        DestinationManager _destinationManager = new DestinationManager(new EfDestinationDal()); //d.m dan nesne ürettik icerisine Efddal'dan ozellikler gelicek
        public IActionResult Index()
        {
            var values = _destinationManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddDestination(Destination destination)  //destination dan destination parametresi alıyor post islemi
        {
            _destinationManager.TAdd(destination);  //_destinationManager  gelen parametreyi ekle
            return RedirectToAction("Index");       //Index sayfasına yonlendir

        }

        public IActionResult DeleteDestination(int id) // Destination silme islemi icin method id parametre aliyor
        {
            var values = _destinationManager.GetTByID(id);  //_destinationManager'den gelen id yi values atiyoruz
            _destinationManager.TDelete(values);            //gelen values ' i siliyoruz
            return RedirectToAction("Index");               //ındex sayfasine yonlendirme
        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)   //guncelleme icin method int id parametre aliyor get islemi
        {
            var values = _destinationManager.GetTByID(id);      //_destinationManager gelen id yi values atiyoruz
            return View(values);                                //bu values degerini geri donduruyoruz
        }

        [HttpPost]
        public IActionResult UpdateDestination(Destination destination) //guncelleme icin method Destinationdan destination parametre aliyor post islemi
        {
            _destinationManager.TUpdate(destination);           //_destinationManager gelen parametreyi TUpdate metoduyla guncelliyoruz
            return RedirectToAction("Index");                   //Index Sayfasina yonlendirme
        }

    }
}
