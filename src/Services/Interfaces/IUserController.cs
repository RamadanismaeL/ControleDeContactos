using controleDeContactos.src.Models;
using Microsoft.AspNetCore.Mvc;
/**
** @author Ramadan IsmaeL
*/
namespace controleDeContactos.src.Services.Interfaces
{
    public interface IUserController
    {
        Task<ActionResult<UserModel>> Create([FromBody] UserModel userModel);
        Task<ActionResult<List<UserModel>>> ReadAll();
        Task<ActionResult<UserModel>> Update([FromBody] UserModel userModel, int id);
        Task<ActionResult<UserModel>> Delete(int id);
        Task<ActionResult<UserModel>> FindByID(int id);
    }
}