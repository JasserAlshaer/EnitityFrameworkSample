using EnitityFrameworkSample.Context;
using EnitityFrameworkSample.DTO;
using EnitityFrameworkSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnitityFrameworkSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly SampleContextDb _context;
        public MainController(SampleContextDb context)
        {
            _context = context;
        }
        //Get All In Specific Table 
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllDoctors()
        {
            var res = _context.Doctors.ToList();
            return Ok(res);
        }
        //Get By Id 
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetDoctorById(int Id)
        {
            var res = _context.Doctors.Where(x => x.Id == Id).FirstOrDefault();
            //var res1 = _context.Doctors.Where(x => x.Id == Id).Single();
            //var res2 = _context.Doctors.Where(x => x.Id == Id).Last();
            return Ok(res);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult SearchOnPaitent(string? name, string? email, string? phone)
        {
            var result = new List<Paitent>();
            if (name == null && email == null && phone == null)
            {
                // keep the empty list 
            } else if (name != null && email == null && phone == null)
            {
                //Filltering With Name
                result = _context.Paitents.Where(x => x.Name.Contains(name)).ToList();
            }
            else if (name == null && email != null && phone == null)
            {
                //Filltering With Email
                result = _context.Paitents.Where(x => x.Email.Contains(email)).ToList();
            }
            else if (name == null && email == null && phone != null)
            {
                //Filltering With Phone
                result = _context.Paitents.Where(x => x.Phone.Contains(phone)).ToList();
            }
            else if (name != null && email != null && phone == null)
            {
                //Filltering With Email And Name 
                result = _context.Paitents.Where(x => x.Email.Contains(email)
                || x.Name.Contains(name)).ToList();
            }
            else if (name != null && email == null && phone != null)
            {
                //Filltering With Phone And Name 
                result = _context.Paitents.Where(x => x.Phone.Contains(phone)
                || x.Name.Contains(name)).ToList();
            }
            else if (name == null && email != null && phone != null)
            {
                //Filltering With Phone And Email 
                result = _context.Paitents.Where(x => x.Phone.Contains(phone)
                || x.Email.Contains(email)).ToList();
            }
            else
            {
                //Filltering With Phone And Email 
                result = _context.Paitents.Where(x => x.Phone.Contains(phone)
                || x.Email.Contains(email) || x.Name.Contains(name)).ToList();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateNewPaitent(CreatePaitentRecord dto)
        {
            Paitent p1 = new Paitent();
            p1.Name = dto.Name;
            p1.Email = dto.Email;
            p1.Phone = dto.Phone;
            p1.Bio = dto.Bio;
            _context.Add(p1);
            _context.SaveChanges();
            return Ok("New Client Has Been  Added");
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateNewLogin(CreateLoginDTO dto)
        {
            var record = await _context.Paitents.FirstOrDefaultAsync(x => x.Id == dto.PaitentId);
            Login p1 = new Login();
            p1.UserName = dto.Email;
            p1.Password = dto.Password;
            p1.Paitent = record;
            _context.Add(p1);
            await _context.SaveChangesAsync();
            return Ok("New Login Has Been  Added");
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateNewPaitentWithLogin(CreateNewPaitentWithLoginDTO dto)
        {
            Paitent p1 = new Paitent();
            p1.Name = dto.Name;
            p1.Email = dto.Email;
            p1.Phone = dto.Phone;
            p1.Bio = dto.Bio;
            _context.Add(p1);
            _context.SaveChanges();
            int id = p1.Id;
            //**********************************************
            Login login = new Login();
            login.UserName = dto.Email;
            login.Password = dto.Password;
            login.Paitent = p1;
            _context.Add(login);
            _context.SaveChanges();
            return Ok("New Login Has Been  Added");
        }
        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdatePatientProfile(int Id, string bio)
        {
            //find the row / object 
            var paitent = _context.Paitents.Find(Id);
            //check if record exisit
            if (paitent != null)
            {
                paitent.Bio = bio;
                paitent.Phone = "55154358456535";
                _context.Update(paitent);
                _context.SaveChanges();
                return Ok("Client Has Been  Updated");
            }
            return NoContent();
        }
        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateLoginRecord(int Id, int paitentId)
        {
            var paitent = _context.Paitents.Find(paitentId);
            var login = _context.Logins.Find(Id);
            


            _context.Update(login);
            _context.SaveChanges();
            return Ok("Login Has Been  Updated");
        }
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeletePaitent(int Id)
        {
            //check if exisit 
            if (_context.Paitents.Any(x => x.Id == Id))
            {
                var paitent = _context.Paitents.Find(Id);
                _context.Remove(paitent);
                _context.SaveChanges();
                return Ok("Remove Successfully");
            }
            return Ok("No Any Paitent To Remove");
        }
    }
}
