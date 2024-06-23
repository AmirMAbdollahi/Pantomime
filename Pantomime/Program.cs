// See https://aka.ms/new-console-template for more information

using Pantomime.DbContexts;
using Pantomime.Entities;
using Pantomime.Repo;
using Pantomime.Services;

var wordService=new WordService(new Repositories<Word>(new PantomimeDbContext()));

var words=wordService.GetAll();

Console.ReadKey();

