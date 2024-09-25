using UnderstandingStructure.Interfaces;
using UnderstandingStructure.Models;
using UnderstandingStructure.Exceptions;

namespace UnderstandingStructure.Repository
{
    public class PizzaImageRepository:IRepository<int,PizzaImages>
    {
        List<PizzaImages> images = new List<PizzaImages>
        {
            new PizzaImages(){Id = 1, Images = new List<string>(){ "margherita.jpg", "margherita2.jpg", "margherita3.jpg" } },
            new PizzaImages(){Id = 2, Images = new List<string>(){ "pepperoni.jpg", "pepperoni2.jpg", "pepperoni3.jpg" } }
        };
        public void Add(PizzaImages item)
        {
            if (item.Images.Count == 0)
                throw new CannotAddWithNoImageException();
            images.Add(item);
            //return item;
        }

        public PizzaImages Delete(int key)
        {
            var myImages = Get(key);
            if (myImages == null)
                //throw new NoSuchImageException()
                throw new FormatException();
            images.Remove(myImages);
            return myImages;
        }

        public PizzaImages Get(int key)
        {
            var imgage = images.FirstOrDefault(i => i.Id == key);
            if (imgage == null)
                //throw new NoSuchImageException();
                throw new Exception();
            return imgage;
        }

        public List<PizzaImages> GetAll()
        {
            if (images.Count == 0)
                //throw new NoImagesException();
                throw new Exception();
            return images;
        }

        public PizzaImages Update(PizzaImages pizza)
        {
            if (pizza.Images.Count == 0)
                //throw new CannotUpdateWithNoImagesException();
                throw new Exception();
            var myImages = Get(pizza.Id);
            if (myImages == null)
                //throw new NoSuchImageException();
                throw new Exception();
            myImages.Images = pizza.Images;
            return myImages;
        }
    }
}
