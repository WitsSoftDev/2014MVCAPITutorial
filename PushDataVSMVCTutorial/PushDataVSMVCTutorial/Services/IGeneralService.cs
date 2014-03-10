using System.Drawing;

namespace PushDataVSMVCTutorial.Services
{
    public interface IGeneralService
    {
        byte[] ImageToByteArray(Image imageIn);
        Image ByteArrayToImage(byte[] byteArrayIn);
        byte[] GetBytes(string str);
        string GetString(byte[] bytes);
    }
}