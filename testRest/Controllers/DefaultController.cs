using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace testRest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [Route("/")]
        public String rootPath()
        {
            return "hello world";
        }

        Process sound = new Process()
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "aplay",
                Arguments = "/home/cubox/Desktop/kc_test/test.wav",
                RedirectStandardOutput = false,
                RedirectStandardError = false,
                UseShellExecute = true,
                CreateNoWindow = true
            }
        };

        [Route("/test/sound/on")]
        public void testSoundOn()
        {
            sound.Start();
        }

        /*[Route("/test/lcd/{bright:int}")]
        public void testLCDBright(int bright)
        {
            Process lcd = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "bash",
                    Arguments = string.Format("-c echo \"1000,{0}\" > /sys/devices/platform/pwm/pwm.2", bright),
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    UseShellExecute = true,
                    CreateNoWindow = true
                }
            };

            lcd.Start();
        }*/

        [Route("/test/lcd/40")]
        public void testLCD40Bright(int bright)
        {
            Process lcd = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "bash",
                    Arguments = "./lcd_test_40.sh",
                    WorkingDirectory = "/home/cubox/CUDM",
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    UseShellExecute = true,
                    CreateNoWindow = true
                }
            };

            lcd.Start();
        }

        [Route("/test/lcd/90")]
        public void testLCD90Bright(int bright)
        {
            Process lcd = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "bash",
                    Arguments = "./lcd_test_90.sh",
                    WorkingDirectory = "/home/cubox/CUDM",
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    UseShellExecute = true,
                    CreateNoWindow = true
                }
            };

            lcd.Start();
        }
    }
}