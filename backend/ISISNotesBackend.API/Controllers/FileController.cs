using System;
using ISISNotesBackend.Core;
using ISISNotesBackend.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ISISNotesBackend.API.Controllers
{
    [Route("file")]
    public class FileController : Controller
    {
        private readonly IFacade _facade;
        private readonly IConfiguration _configuration;
        private string Path => _configuration["Database:StoredFilesPath"];

        public FileController(IFacade facade, IConfiguration configuration)
        {
            _facade = facade;
            _configuration = configuration;
        }

        /// <summary>
        /// Добавляет файл в хранилище.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, который добавил файл.</param>
        /// <param name="file">Файл, полученный из POST-запроса.</param>
        /// <returns>Результат действия Ok с информацией о добавленном файле в случае успеха, иначе - NotFound.</returns>
        [Authorize]
        [Route("{userId}")]
        [HttpPost]
        public IActionResult AddFile(string userId, [FromBody] FileWithContent file)
        {
            try
            {
                return Ok(_facade.AddFile(userId, file, Path));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        /// <summary>
        /// Возвращает содержимое файла.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, который хочет получить содержимое файла.</param>
        /// <param name="fileId">Идентификатор файла, содержимое которого нужно получить.</param>
        /// <returns>Результат действия Ok с содержимым файла в случае успеха, иначе - NotFound.</returns>
        [Authorize]
        [Route("{userId}/{fileId}")]
        [HttpGet]
        public IActionResult GetFile(string userId, string fileId)
        {
            try
            {
                return Ok(_facade.GetFile(userId, fileId, Path));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        /// <summary>
        /// Удаляет файл из хранилища.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, который хочет удалить файл.</param>
        /// <param name="fileId">Идентификатор файла, который нужно удалить.</param>
        /// <returns>Результат действия Ok с информацией об удаленном файле в случае успеха, иначе - NotFound.</returns>
        [Authorize]
        [Route("{userId}/{fileId}")]
        [HttpDelete]
        public IActionResult DeleteFile(string userId, string fileId)
        {
            try
            {
                return Ok(_facade.DeleteFile(userId, fileId, Path));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}