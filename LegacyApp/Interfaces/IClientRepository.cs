using LegacyApp.Entities;

namespace LegacyApp.Interfaces;

public interface IClientRepository
{
    Client GetById(int clientId);
}