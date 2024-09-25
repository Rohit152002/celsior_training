using System.Net.Http.Headers;
using DoctorList.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorList.Controllers
{
    public class DoctorController : Controller
    {
        private IWebHostEnvironment Environment;

        public DoctorController(IWebHostEnvironment environment)
        {
            Environment = environment;
        }

        static List<DoctorModel> doctors = new List<DoctorModel>{
        new DoctorModel{Id=1, Name="John Doe", Email="john.doe@gmail.com", Phone=8123456789, Speciality="Neurosurgeon", Image="https://img.freepik.com/free-photo/beautiful-young-female-doctor-looking-camera-office_1301-7807.jpg?size=626&ext=jpg&ga=GA1.1.2008272138.1726704000&semt=ais_hybrid"},
new DoctorModel{Id=2, Name="Jane Smith", Email="jane.smith@gmail.com", Phone=8123456790, Speciality="Cardiologist", Image="https://png.pngtree.com/png-clipart/20230927/original/pngtree-photo-men-doctor-physician-chest-smiling-png-image_13143575.png"},
new DoctorModel{Id=3, Name="William Turner", Email="william.turner@gmail.com", Phone=8123456791, Speciality="Orthopedic Surgeon", Image="https://img.freepik.com/free-photo/medium-shot-smiley-doctor-with-coat_23-2148814212.jpg"},
new DoctorModel{Id=4, Name="Emma Watson", Email="emma.watson@gmail.com", Phone=8123456792, Speciality="Dermatologist", Image="https://static.vecteezy.com/system/resources/thumbnails/041/409/059/small_2x/ai-generated-a-female-doctor-with-a-stethoscope-isolated-on-transparent-background-free-png.png"},
new DoctorModel{Id=5, Name="David Brown", Email="david.brown@gmail.com", Phone=8123456793, Speciality="Pediatrician", Image="https://r2.erweima.ai/imgcompressed/img/compressed_7d50451d01b47b50753b6ac25d29a672.webp"},
new DoctorModel{Id=6, Name="Sophia Miller", Email="sophia.miller@gmail.com", Phone=8123456794, Speciality="Ophthalmologist", Image="https://t4.ftcdn.net/jpg/03/20/52/31/360_F_320523164_tx7Rdd7I2XDTvvKfz2oRuRpKOPE5z0ni.jpg"},

    };
        public IActionResult Index()
        {
            return View(doctors);
        }
        [HttpGet]
        public IActionResult Create()
        {
            DoctorModel doctor = new DoctorModel();
            return View(doctor);
        }
        [HttpPost]
        public IActionResult Create(DoctorModel doctor)
        {
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            string path = Path.Combine(this.Environment.WebRootPath, "images");
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

           if(doctor.PostedFiles !=null && doctor.PostedFiles.Any())
            {
                foreach(IFormFile postedFile in doctor.PostedFiles)
                {
                    string fileName = Path.GetFileName(postedFile.FileName);
                    string filePath = Path.Combine(path, fileName);

                    using (FileStream stream = new FileStream(filePath,FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                    }
                    Console.WriteLine(fileName);
                    doctor.Image = "images/"+fileName;
                }
            }
            doctors.Add(doctor);
            Console.WriteLine(doctor.Image);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            DoctorModel? doctor = doctors.FirstOrDefault(x => x.Id == id);
            Console.WriteLine(id);
            return View(doctor);
        }

        [HttpPost]
        public IActionResult Edit(int id, DoctorModel doctor)
        {
            DoctorModel? oldDoctorDetail = doctors.FirstOrDefault(p => p.Id == id);
            System.Console.WriteLine(doctor.Name);
            oldDoctorDetail.Name = doctor.Name;
            oldDoctorDetail.Speciality = doctor.Speciality;
            oldDoctorDetail.Email = doctor.Email;
            oldDoctorDetail.Phone = doctor.Phone;
            oldDoctorDetail.Image = "images/" + doctor.Image;
            System.Console.WriteLine("images/" + doctor.Image);
            return RedirectToAction("Index");
        }

        // [HttpGet]
        // public IActionResult Delete(int id)
        // {
        //     return View();
        // }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            // DoctorModel? olddoctor = doctors.FirstOrDefault(p=>p.Id==pid);
            System.Console.WriteLine(id);
            System.Console.WriteLine("Delete");
            DoctorModel? doctor = doctors.FirstOrDefault(p => p.Id == id);
            System.Console.WriteLine(doctor.Name);
            doctors.Remove(doctor);
            return RedirectToAction("Index");
        }
    }
}
