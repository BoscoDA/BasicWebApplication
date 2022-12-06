using BasicWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Runtime.CompilerServices;

namespace BasicWebApplication.Controllers
{
    public class AmpController : Controller
    {
        public static IAmpRepo? repo;

        public AmpController(IAmpRepo _repo)
        {
            
            if(repo == null)
                repo = _repo;
        }

        // GET: AmpController
        public ActionResult Index()
        {
            return View(((AmpRepo)repo!).Amps);
        }

        // GET: AmpController/Details/5
        public ActionResult Details(int id)
        {
            return View(repo!.GetAmpById(id));
        }

        // GET: AmpController/Create
        public ActionResult Create()
        {
            return View(new Amp());
        }

        // POST: AmpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Amp a)
        {
            repo!.AddAmp(a);
            return RedirectToAction(nameof(Index));
        }

        // GET: AmpController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo!.GetAmpById(id));
        }

        // POST: AmpController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Knob updateVolume = new Knob()
                {
                    Setting = int.Parse(collection["VolumeKnob.Setting"])
                };

                Knob updateBass = new Knob()
                {
                    Setting = int.Parse(collection["BassKnob.Setting"])
                };

                Knob updateMiddle = new Knob()
                {
                    Setting = int.Parse(collection["MiddleKnob.Setting"])
                };

                Knob updateTreble = new Knob()
                {
                    Setting = int.Parse(collection["TrebleKnob.Setting"])
                };

                Amp updateAmp = new Amp()
                {
                    ID = int.Parse(collection["ID"]),
                    Model = collection["Model"],
                    Powered = Convert.ToBoolean(collection["Powered"][0]),
                    PluggedIn = Convert.ToBoolean(collection["PluggedIn"][0]),
                    VolumeKnob = updateVolume,
                    BassKnob = updateBass,
                    MiddleKnob = updateMiddle,
                    TrebleKnob = updateTreble
                };


                foreach (Amp d in repo!.Amps)
                {
                    if (d.ID == updateAmp.ID)
                    {
                        d.Model = updateAmp.Model;
                        d.Powered = updateAmp.Powered;
                        d.PluggedIn = updateAmp.PluggedIn;
                        d.VolumeKnob.TurnKnobClockwise(updateAmp.VolumeKnob.Setting);
                        d.BassKnob.TurnKnobClockwise(updateAmp.BassKnob.Setting);
                        d.MiddleKnob.TurnKnobClockwise(updateAmp.MiddleKnob.Setting);
                        d.TrebleKnob.TurnKnobClockwise(updateAmp.TrebleKnob.Setting);
                    };
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AmpController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repo!.GetAmpById(id));
        }

        // POST: AmpController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection = null)
        {
            repo.RemoveAmp(repo.GetAmpById(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
