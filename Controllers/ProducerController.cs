


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[Authorize(Roles ="Admin")]
public class ProducerController : Controller {
    private IProducerService _producer;
    private IMovieService _movie;
    public ProducerController(IProducerService producer, IMovieService movieService)
    {
        _producer = producer;
        _movie = movieService;
    }
    [AllowAnonymous]
    public IActionResult Index(){
        var result = _producer.GetAll();
        return View(result);
    }

    [HttpGet]
    public IActionResult New(){
        return View();
    }


    [HttpPost]
    public IActionResult New([Bind("Name, ImgUrl, Bio")]Producer producer){
        if(!ModelState.IsValid){
            return Content("Error on model state");
        }
        _producer.Add(producer);
        return RedirectToAction("Index");
    }
    //[Authorize(Roles ="Admin, New")]
    [AllowAnonymous]
    public IActionResult Details(int id){
        var result = _producer.GetById(id);
        var movis = _movie.GetAll().Where(x => x.ProducerId == id).ToList();
        result.Movies = movis;
        return View(result);
    }

    public IActionResult Edit(int id){
        var result = _producer.GetById(id);
        return View(result);
    }
    [HttpPost]
    public IActionResult Edit(int id, [Bind("Name, ImgUrl, Bio")]Producer producer){
        if(!ModelState.IsValid){
            return Content("Error on model state");
        }
        _producer.Update(id, producer);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id){
        var result = _producer.GetById(id);
        _producer.Delete(result);
        return RedirectToAction("Index");
    }

    

}