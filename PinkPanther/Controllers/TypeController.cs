using Microsoft.AspNetCore.Mvc;
using PinkPanther.Core;
using PinkPanther.Mappers;
using PinkPanther.Models;

namespace PinkPanther.Controllers
{
    public class TypeController : Controller
    {
        readonly ViewModelMapper _mapper;
        readonly IManager _manager;

        public TypeController(IManager manager, ViewModelMapper mapper)
        {
            _mapper = mapper;
            _manager = manager;
        }
        public IActionResult Index()
        {
            var types = _manager.GetTypes();
            return View(_mapper.Map(types)); 
        }

        [HttpPost]
        public IActionResult Add(string type)
        {
            if(string.IsNullOrEmpty(type)) return RedirectToAction("Index", "Type");

            _manager.AddType(new TypeDto() { TypeName = type });
            return RedirectToAction("Index", "Type");
        }

        public IActionResult Delete(int id)
        {
            _manager.DeleteType(id);

            return RedirectToAction("Index", "Type");
        }

        public IActionResult Modify(int id)
        {
            var types = _manager.GetTypes();
            var type = types.Where(type => type.Id == id).FirstOrDefault();
            if(type != null)
            {
                return View(_mapper.Map(type));
            }
            return RedirectToAction("Index", "Type");
        }

        public IActionResult Change(int id, string type)
        {
            if (!string.IsNullOrEmpty(type))
            {
                var typevm = new TypeViewModel() { Id = id, TypeName = type };

                _manager.UpdateType(_mapper.Map(typevm));

            }
            return RedirectToAction("Index", "Type");
        }

        
    }
}
