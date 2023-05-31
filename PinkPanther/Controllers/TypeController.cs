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
        public IActionResult Add(TypeViewModel typeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var typeDto = _mapper.Map(typeViewModel);

            _manager.AddType(typeDto);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _manager.DeleteType(id);

            return RedirectToAction("Index", "Type");
        }

        public IActionResult GoToModify(int id)
        {
            var type = _manager.GetTypes().Where(type => type.Id == id).FirstOrDefault();

            if(type == null)
            {
                return RedirectToAction("Index");
            }

            var typeViewModel = _mapper.Map(type);

            return View("Modify", typeViewModel);
        }

        public IActionResult Modify(TypeViewModel typeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var typeDto = _mapper.Map(typeViewModel);

            _manager.UpdateType(typeDto);

            return RedirectToAction("Index");
        }

        
    }
}
