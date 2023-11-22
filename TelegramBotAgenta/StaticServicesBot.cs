using Microsoft.EntityFrameworkCore;
using TelegramBotAgenta.Data;
using TelegramBotAgenta.Models;

namespace TelegramBotAgenta
{
    public static  class StaticServicesBot
    {
        private static DBDataAccess _db = new DBDataAccess();
        

        public static async Task<bool> SearchUserAsync(string username)
         
        {
            try
            {

                var user = await _db.Users.FirstOrDefaultAsync(x=>x.UserName==username);
                if (user != null)
                {
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public static async Task<int> GetUserByIdAsync(string username)

        {
            

                Users user = await _db.Users.FirstOrDefaultAsync(x => x.UserName == username);

                return user.Id;
            
        }


        public static async Task<bool> AddTodoAsync(Todos user)
        {
            try
            {
                await _db.Todos.AddAsync(user);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static async Task<bool> AddUserAsync(Users user) 
        {
            try
            {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<List<Todos>> getAlltodos(int userid)
        {
            var tos = await  _db.Todos.Where(x=>x.UsersId==userid).ToListAsync();
            return tos;
        }


    }
}
