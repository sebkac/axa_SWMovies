using System;
using System.Collections.Generic;
using System.Text;

namespace SWapiRepository
{
    static public class FilmService
    {
        private static IRepository<Film> _filmsRepo;

        public static ICollection<Film> GetAllSWFilms()
        {
            try
            {
                _filmsRepo = new Repository<Film>();
                var films = _filmsRepo.GetEntities(size: int.MaxValue);

                return films;
            }
            catch(Exception ex)
            {
                //log error
                return null;
            }
        }
    }
}
