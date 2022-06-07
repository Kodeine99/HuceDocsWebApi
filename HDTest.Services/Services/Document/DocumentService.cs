using HuceDocs.Data.Repository;
using HuceDocs.Services.Services;
using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels.Document;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services
{
    public class DocumentService
    {
        private UnitOfWork work;
        private readonly ILogger<DocumentService> _logger;
        private readonly IUserService _userService;

        private readonly ExtrConfigModel _extrConfigModel;


    }
}
