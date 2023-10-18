using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundControlClass
{
    /// <summary>
    /// Using MCI Sound Control class
    /// </summary>
    static class SoundControl
    {
        [System.Runtime.InteropServices.DllImport("winmm.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static private extern int mciSendString(string command, System.Text.StringBuilder buffer, int bufferSize, IntPtr hwndCallback);
        static private string aliasName = "MediaFile";

        static void Play(string fileName)
        {
            string cmdString;
            cmdString = "close " + aliasName;
            mciSendString(cmdString, null, 0, IntPtr.Zero);

            cmdString = "open \"" + fileName + "\" alias " + aliasName;
            if (mciSendString(cmdString, null, 0, IntPtr.Zero) != 0) return;
            cmdString = "play " + aliasName;
            mciSendString(cmdString, null, 0, IntPtr.Zero);

        }

        static void SetVolume(int volume)
        {
            string cmdString;
            cmdString = "setaudio " + aliasName + " volume to " + volume.ToString();
            mciSendString(cmdString, null, 0, IntPtr.Zero);

        }

    }
}
