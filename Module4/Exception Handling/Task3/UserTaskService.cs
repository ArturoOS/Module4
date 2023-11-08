using System;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskService
    {
        private readonly IUserDao _userDao;

        public UserTaskService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public void AddTaskForUser(int userId, UserTask task, out int errorCode)
        {
			try
			{
                errorCode = 0;
                if (userId < 0)
                    throw new Exception("-1");

                var user = _userDao.GetUser(userId);
                if (user == null)
                    throw new Exception("-2");

                var tasks = user.Tasks;
                foreach (var t in tasks)
                {
                    if (string.Equals(task.Description, t.Description, StringComparison.OrdinalIgnoreCase))
                        throw new Exception("-3");
                }

                tasks.Add(task);
            }
			catch (Exception e)
			{
                errorCode = Int32.Parse(e.Message);
                return;
			}
            
        }
    }
}