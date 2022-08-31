using DataFile.Models;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;
using System;
using System.Linq;

namespace AIProject.Service
{
    public class NeuralNetworkRepository
    {
        protected readonly ApplicationDbContext context;
        public NeuralNetworkRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

       
         public IQueryable<NeuralNetworkType> GetNetworkTypes()
        {
            return context.NeuralNetworkTypes;
        }
        public IQueryable<NeuralNetworkModel> GetNeuralNetworkModel()
        {
            return context.NeuralNetworkModels;
        }

        public IQueryable<NeuralNetworkModel> GetNeuralNetworksByUserId(string userId)
        {
            return context.NeuralNetworkModels.Where(nn => nn.UserId == userId).OrderBy(nn => nn.CreationDate);
        }

        public NeuralNetworkModel GetNeuralNetwork(Guid id)
        {
            return context.NeuralNetworkModels.Single(nn => nn.Id == id);
        }

        public NeuralNetworkType GetNetworkType(Guid id)
        {
            return context.NeuralNetworkTypes.Single(t => t.Id == id);
        }

        public Guid SaveNeuralNetworkModel(NeuralNetworkModel model)
        {
            if (model.Id == default)
                context.Entry(model).State = EntityState.Added;
            else
                context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();

            return model.Id;
        }

        public void DeleteNeuralNetworkModel(NeuralNetworkModel model)
        {
            context.NeuralNetworkModels.Remove(model);
            context.SaveChanges();
        }
    }
}
