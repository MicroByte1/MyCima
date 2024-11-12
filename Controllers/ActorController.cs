


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles ="Admin")]
public class ActorController : Controller {
    IActorService _actor;
    private IMovieService _movie;
    public ActorController(IActorService actor, IMovieService movieService)
    {
        _actor = actor;
        _movie = movieService;
    }
    [AllowAnonymous]
    public IActionResult Index(){
        var result = _actor.GetAll();
        return View(result);
    }


    [HttpGet]
    public IActionResult New(){
        return View();
    }


    [HttpPost]
    public IActionResult New([Bind("Name, ImgUrl, Bio")]Actor actor){
        /*if(!ModelState.IsValid){
            return Content("Error on model state");
        }*/
        _actor.Add(actor);
        return RedirectToAction("Index");
    }
    //[Authorize(Roles ="Admin, New")]
    [AllowAnonymous]
    public async Task<IActionResult> Details(int id){
        var actor = _actor.GetById(id);
        var vm = new ActorVM(actor);
        vm.movies = await _movie.GetAllMoviesByActorId(id);
        return View(vm);
    }

    public IActionResult Edit(int id){
        var result = _actor.GetById(id);
        return View(result);
    }
    [HttpPost]
    public IActionResult Edit(int id, [Bind("Name, ImgUrl, Bio")]Actor actor){
        if(!ModelState.IsValid){
            return Content("Error on model state");
        }
        _actor.Update(id, actor);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id){
        var result = _actor.GetById(id);
        _actor.Delete(result);
        return RedirectToAction("Index");
    }


}