using System.Collections.Generic;
using System.Linq;
using FormsApp.Model;
using SQLite;

namespace FormsApp.Model
{
    public class Context
    {
        SQLiteConnection database;
        public Context(string databasePath)
        {
            database = new SQLiteConnection(databasePath);

            database.CreateTable<Answer>();
            database.CreateTable<Category>();
            database.CreateTable<Question>();
            database.CreateTable<Test>();
            database.CreateTable<Exercise>();
            database.CreateTable<Norm>();
            database.CreateTable<Result>();
            database.CreateTable<User>();
        }

        #region User
        public IEnumerable<User> GetUsers()
        {
            return database.Table<User>().ToList();
        }
        public User GetUser(int id)
        {
            return database.Get<User>(id);
        }
        public int DeleteUser(int id)
        {
            return database.Delete<User>(id);
        }
        public int SaveUser(User item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        #endregion

        #region Test

        public IEnumerable<Test> GetTests()
        {
            return database.Table<Test>().ToList();
        }
        public Test GetTest(int id)
        {
            Test test = database.Get<Test>(id);
            test.Questions = GetQuestionsByTest(id).ToList();
            return test;
        }
        public IEnumerable<Test> GetTestsByCategory(int id)
        {
            return database.Table<Test>().Where(x => x.CategoryId == id).ToList();
        }
        public int DeleteTest(int id)
        {
            return database.Delete<Test>(id);
        }
        public int SaveTest(Test item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        #endregion

        #region Result

        public IEnumerable<Result> GetResults()
        {
            return database.Table<Result>().ToList();
        }
        public Result GetResult(int id)
        {
            return database.Get<Result>(id);
        }
        public int DeleteResult(int id)
        {
            return database.Delete<Result>(id);
        }
        public int SaveResult(Result item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        #endregion

        #region Question

        public IEnumerable<Question> GetQuestions()
        {
            return database.Table<Question>().ToList();
        }
        public IEnumerable<Question> GetQuestionsByTest(int testId)
        {
            List<Question> questions = database.Table<Question>().Where(x => x.TestId == testId).ToList();
            foreach (var x in questions)
                x.Answers = GetAnswersByQuestion(x.Id).ToList();
            return questions;
        }
        public IEnumerable<Question> GetQuestionsByExercise(int exId)
        {
            List<Question> questions = database.Table<Question>().Where(x => x.ExerciseId == exId).ToList();
            foreach (var x in questions)
                x.Answers = GetAnswersByQuestion(x.Id).ToList();
            return questions;
        }
        public Question GetQuestion(int id)
        {
            return database.Get<Question>(id);
        }
        public int DeleteQuestion(int id)
        {
            return database.Delete<Question>(id);
        }
        public int SaveQuestion(Question item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        #endregion

        #region Norm

        public IEnumerable<Norm> GetNorms()
        {
            return database.Table<Norm>().ToList();
        }
        public Norm GetNorm(int id)
        {
            return database.Get<Norm>(id);
        }
        public int DeleteNorm(int id)
        {
            return database.Delete<Norm>(id);
        }
        public int SaveNorm(Norm item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        #endregion

        #region Exercise

        public IEnumerable<Exercise> GetExercises()
        {
            return database.Table<Exercise>().ToList();
        }
        public Exercise GetExercise(int id)
        {
            Exercise ex = database.Get<Exercise>(id);
            ex.Questions = GetQuestionsByExercise(id).ToList();
            return ex;

            return database.Get<Exercise>(id);
        }
        public int DeleteExercise(int id)
        {
            return database.Delete<Exercise>(id);
        }
        public int SaveExercise(Exercise item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        #endregion

        #region Category

        public IEnumerable<Category> GetCategories()
        {
            return database.Table<Category>().ToList();
        }
        public Category GetCategory(int id)
        {
            return database.Get<Category>(id);
        }
        public int DeleteCategory(int id)
        {
            return database.Delete<Category>(id);
        }
        public int SaveCategory(Category item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        #endregion

        #region Answers

        public IEnumerable<Answer> GetAnswers()
        {
            return database.Table<Answer>().ToList();
        }
        public IEnumerable<Answer> GetAnswersByQuestion(int questionId)
        {
            return database.Table<Answer>().Where(x => x.QuestionId == questionId).ToList();
        }
        public Answer GetAnswer(int id)
        {
            return database.Get<Answer>(id);
        }
        public int DeleteAnswer(int id)
        {
            return database.Delete<Answer>(id);
        }
        public int SaveAnswer(Answer item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        #endregion
    }
}