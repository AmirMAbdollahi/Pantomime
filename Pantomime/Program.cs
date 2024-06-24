// See https://aka.ms/new-console-template for more information

using Pantomime.DbContexts;
using Pantomime.Entities;
using Pantomime.Repo;
using Pantomime.Services;

var teamService=new TeamService(new Repositories<Team>(new PantomimeDbContext()));

var words=teamService.GetAll();

Console.ReadKey();

