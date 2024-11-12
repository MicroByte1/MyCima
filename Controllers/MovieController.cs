

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles ="Admin")]
public class MovieController : Controller {

    IMovieService _movie;

    IActorService _actor;

    IProducerService _producer;

    public MovieController(IMovieService movie, IActorService actor, IProducerService producer)
    {
        _movie = movie;
        _actor = actor;
        _producer = producer;
    }
    [AllowAnonymous]
    public IActionResult Index(string movieName){
        var result = _movie.GetAll();
        if (movieName != null){
            result = result.Where(x => x.Name.ToLower().Contains(movieName.ToLower()));
        }
        var vmresult = new List<MovieVM>();
        foreach (var item in result){
            item.Producer = _producer.GetById(item.ProducerId);
            vmresult.Add(new MovieVM(item));
        }
        return View(vmresult);
    }

    [HttpGet]
    public IActionResult New(){
        var result = _actor.GetAll();
        ViewBag.actors = result;
        return View();
    }


    [HttpPost]
    public IActionResult New(MovieVM movievm){
        Movie model = movievm.ToModel();
        _movie.AddMovie(model);
        return RedirectToAction("Index");
    }

    [AllowAnonymous]
    public async Task<IActionResult> Details(int id){
        var result = _movie.GetById(id);
        var vm = new MovieVM(result);
        vm.Producer = _producer.GetById(vm.ProducerId);
        vm.Actors = await _actor.GetAllActorsByMoviId(id);
        return View(vm);
    }

    [AllowAnonymous]
    public IActionResult CategoryFilter(int id){
        var result = _movie.GetAll();
        var res2 = result.Where(x => (int)x.Category == id);
        var vmresult = new List<MovieVM>();
        foreach (var item in res2){
            item.Producer = _producer.GetById(item.ProducerId);
            vmresult.Add(new MovieVM(item));
        }
        return View("Index", vmresult);
    }

}