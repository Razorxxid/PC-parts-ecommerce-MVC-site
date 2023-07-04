using e_commerce.Models.asbstractClasses;

namespace e_commerce.Models.implementations
{
    public class VideoCard : AbstractProduct
    {

        private string? assembler;
        private int memoryInGB;
       

        public VideoCard()
        {
        }

        public string? Assembler { get => assembler; set => assembler = value; }
        public int MemoryInGB { get => memoryInGB; set => memoryInGB = value; }
        
    }
}
