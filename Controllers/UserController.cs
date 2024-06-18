using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            // Implement the Index method here
            return View(userlist);
        }
 
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Implement the details method here
            // Find the user in the userlist by their ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found with the provided ID, return a HttpNotFound result
            if (user == null)
            {
                return HttpNotFound();
            }

            // If a user is found, pass the user object to the Details view
            return View(user);
        }
 
        // GET: User/Create
        public ActionResult Create()
        {
            //Implement the Create method here
            // Simply return the Create view. The view will contain the form for creating a new user.
            return View();
        }
 
        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Implement the Create method (POST) here
            // Check if the model state is valid
            if (ModelState.IsValid)
            {
                // Add the new user to the userlist
                userlist.Add(user);

                // Redirect to the Index action to show the list of users
                return RedirectToAction("Index");
            }

            // If the model state is not valid, return the same view to the user for correction
            return View(user);
        }
 
        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.
            // Find the user in the userlist by their ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found with the provided ID, return a HttpNotFound result
            if (user == null)
            {
                return HttpNotFound();
            }

            // If a user is found, pass the user object to the Edit view
            return View(user);
        }
 
        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
            // It receives user input from the form submission and updates the corresponding user's information in the userlist.
            // If successful, it redirects to the Index action to display the updated list of users.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Edit view to display any validation errors.
            // Find the user in the userlist by their ID
            var userToUpdate = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found with the provided ID, return a HttpNotFound result
            if (userToUpdate == null)
            {
                return HttpNotFound();
            }

            // Check if the model state is valid
            if (ModelState.IsValid)
            {
                // Update the user's properties
                userToUpdate.Name = user.Name;
                userToUpdate.Email = user.Email;
                // Add any other properties that need to be updated

                // Redirect to the Index action to show the updated list of users
                return RedirectToAction("Index");
            }

            // If the model state is not valid, return the Edit view to display any validation errors
            return View(user);
        }
 
        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Implement the Delete method here
            // Find the user in the userlist by their ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found with the provided ID, return a HttpNotFound result
            if (user == null)
            {
                return HttpNotFound();
            }

            // If a user is found, pass the user object to the Delete view
            return View(user);
        }
 
        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Implement the Delete method (POST) here
            // Find the user in the userlist by their ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found with the provided ID, return a HttpNotFound result
            if (user == null)
            {
                return HttpNotFound();
            }

            // Remove the user from the userlist
            userlist.Remove(user);

            // Redirect to the Index action to show the updated list of users
            return RedirectToAction("Index");
        }
    }
}
