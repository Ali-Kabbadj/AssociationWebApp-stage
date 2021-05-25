
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication1.Data;
using Location = WebApplication1.Models.Contact_Us.Location;

namespace WebApplication1.Services.LocationService
{
    public class LocationTaskService : ILocationTaskService<Location>
    {

        private readonly ApplicationDbContext db;
        public LocationTaskService(ApplicationDbContext context)
        {
            db = context;
        }

        public virtual IQueryable<Location> GetAll()
        {
            IQueryable<Location> locations = db.Locations.Select(location => new Location
            {
                Id= location.Id,
                Name= location.Name,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Description = location.Description
            });
            return locations;
        }


        public virtual void Insert(Location location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
        }

        public virtual void Update(Location location)
        {
                db.Locations.Attach(location);
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();
        }


        public virtual void Delete(Location location)
        {
            db.Locations.Attach(location);
            db.Locations.Remove(location);
            db.SaveChanges();
        }
        
    }
}
