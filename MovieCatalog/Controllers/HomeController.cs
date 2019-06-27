using MovieCatalog.Content;
using MovieCatalog.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MovieCatalog.Controllers
{
    public class HomeController : Controller
    {
        MoviesContext db = new MoviesContext();

        public ActionResult Index(int page = 1)
        {
            PageClass pc = new PageClass(); 

            int countOnPage = 3; //количество фильмов на странице
            pc.pageMovies = db.Movies.OrderByDescending(x => x.ID).ToList().Skip((page-1) * countOnPage).Take(countOnPage).ToList();
            pc.currPage = page;
            pc.pagesAvaible = new System.Collections.Generic.List<int>();
           
            int pagesCount = (int)(db.Movies.Count() / countOnPage);
            int ost = db.Movies.Count() % (countOnPage * pagesCount);
            pagesCount += ost > 0 ? 1 : 0;
           pc.pagesAvaible.Add(page);

            for (int i = 1; i < 5; i++)
            {
                if (page + i <= pagesCount)
                {
                    pc.pagesAvaible.Add(page + i);
                }

                if (page - i > 0)
                {
                    pc.pagesAvaible.Add(page - i);
                }
            }

            pc.currUser = Session["currUser"] != null ? Session["currUser"].ToString() : "";

            return View(pc);
        }
        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            if (db.Users.Where(x=>x.Login==login && x.Password==password).Count()!=0)
            {
                Session["currUser"] = login;
            }
            else
            {
                Session["error"] = "Введен неверный логин или пароль";
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register(string login, string password)
        {
            if (db.Users.Where(x => x.Login == login && x.Password == password).Count() == 0)
            {
                db.Users.Add(new Users { Login = login, Password = password });
                db.SaveChanges();

                Session["currUser"] = login;
            }
            else
            {
                Session["error"] = "Пользователь с введенным логином уже существует";
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Exit()
        {
            Session["currUser"] = null;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult UpdateMovie(string id)
        {
            if (Session["currUser"] != null)
            {
                Movies movies = new Movies();

                if (id != null)
                {
                    movies = db.Movies.Where(x => x.ID.ToString() == id).FirstOrDefault();
                }

                return View(movies);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult AddChange(string id, string name, string description, string year, string producer, string postersrc)
        {
            if (id!="0")
            {
                Movies movie = db.Movies.Where(x => x.ID.ToString() == id).FirstOrDefault();
                movie.name = name;
                movie.description = description;
                movie.year = Int32.Parse(year);
                movie.producer = producer;
                movie.poster = postersrc;

                db.SaveChanges();
            }
            else
            {
                Movies movie = new Movies();
                movie.name = name;
                movie.description = description;
                movie.year = Int32.Parse(year);
                movie.producer = producer;
                movie.poster = postersrc;
                movie.user = Session["currUser"].ToString();

                db.Movies.Add(movie);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(string id)
        {
            db.Movies.Remove(db.Movies.Where(x => x.ID.ToString() == id).FirstOrDefault());
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Movie(string id)
        {
            return View(db.Movies.Where(x => x.ID.ToString() == id).FirstOrDefault());
        }
    }
}

