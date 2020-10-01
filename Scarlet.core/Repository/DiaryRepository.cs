using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SQLite;

namespace ScarletDairy.Core.Repository
{
 public   class DiaryRepository
  {
        private readonly SQLiteConnection _db;
        public DiaryRepository()
        {
            string dbPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.Personal),
        "database.db3");
            _db = new SQLiteConnection(dbPath);
            Initialize();
        }
        private void Initialize()
        {
          _db.CreateTable<Notes>();
            if (GetNotes().Count == 0)
            {
                try
                {





                    var seed = new List<Notes>
                {
                    new Notes
                    {
                        AudioPath =string.Empty,
                        Id = 1,
                        ImagePath= string.Empty,
                        Location = string.Empty,
                        Text ="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Molestiae iure deleniti provident. Incidunt omnis,illo itaque error totam temporibus corrupti. Voluptatibus sequi aperiam odio nemo praesentium cumque alias quis placeat?"
                    },
                    new Notes
                    {
                        AudioPath =string.Empty,
                        Id = 2,
                        ImagePath= string.Empty,
                        Location = string.Empty,
                        Text ="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Molestiae iure deleniti provident. Incidunt omnis,illo itaque error totam temporibus corrupti. Voluptatibus sequi aperiam odio nemo praesentium cumque alias quis placeat?"
                    },
                    new Notes
                    {
                        AudioPath =string.Empty,
                        Id = 3,
                        ImagePath= string.Empty,
                        Location = string.Empty,
                        Text ="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Molestiae iure deleniti provident. Incidunt omnis,illo itaque error totam temporibus corrupti. Voluptatibus sequi aperiam odio nemo praesentium cumque alias quis placeat?"
                    },
                    new Notes
                    {
                        AudioPath =string.Empty,
                        Id = 4,
                        ImagePath= string.Empty,
                        Location = string.Empty,
                        Text ="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Molestiae iure deleniti provident. Incidunt omnis,illo itaque error totam temporibus corrupti. Voluptatibus sequi aperiam odio nemo praesentium cumque alias quis placeat?"
                    },
                    new Notes
                    {
                        AudioPath =string.Empty,
                        Id = 5,
                        ImagePath= string.Empty,
                        Location = string.Empty,
                        Text ="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Molestiae iure deleniti provident. Incidunt omnis,illo itaque error totam temporibus corrupti. Voluptatibus sequi aperiam odio nemo praesentium cumque alias quis placeat?"
                    }
                };
                    _db.InsertAll(seed, true);
                }

                catch (Exception)
                {
                    _db.Rollback();
                }

            }
        }
        public List<Notes> GetNotes()
        {
            object locker = new object(); // class level private field
            List<Notes> notes = null;               // rest of class code
           
            lock (locker)
            {
            notes =    _db.Table<Notes>().ToList();
                // Do your query or insert here
            }
            return notes;
        }
        public void InsertNotes(Notes note)
        {
            try
            {
              _db.Insert(note);
                
            }
            catch (Exception)
            {

            
            }
        }
        public void UpdateNotes(Notes notes)
        {
            try
            {
                _db.Update(notes);
            }
            catch (Exception)
            {

               
            }
        }
        public void DeleteNote(Notes notes)
        {
            try
            {
                _db.Delete(notes);
            }
            catch (Exception)
            {


            }
        }

    }
}
