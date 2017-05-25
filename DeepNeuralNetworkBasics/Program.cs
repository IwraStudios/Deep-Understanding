using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DeepNeuralNetworkBasics
{
    //Here we are going to make the "basic fully connected neural network" with a sigmoid activation function
    class DeepNeuralNet
    {
        static void Main(string[] args)
        {
            NetNodeContainer Net = new NetNodeContainer();

        }

        class NetContainer
        {
            uint inputAmount = 2;
            uint OutputAmount = 1;
            List<uint> NodesLayers;
            List<List<NetNodeContainer>> Nodes;

            public NetContainer(List<uint> Nodes, uint inputAmount = 2, uint OutputAmount = 1)
            {
                this.inputAmount = inputAmount;
                this.OutputAmount = OutputAmount;
                NodesLayers = Nodes;
            }


            void Generate_Nodes()
            {
                List<List<NetNodeContainer>> Out = new List<List<NetNodeContainer>>();
                List<NetNodeContainer> TMP = new List<NetNodeContainer>();
                for(int i = 0; i < inputAmount; i++) //Generate Output Nodes
                {
                    TMP.Add(new NetNodeContainer() { layer = 0,
                        Weights = Generate_RND_Weights(NodesLayers.First()) //Generate x amount of Random weights(x = the amount of nodes that follow)
                    });
                }
                Out.Add(TMP);
                TMP = new List<NetNodeContainer>();
                for (int i = 0; i < OutputAmount; i++) //Genereate Output Nodes
                {
                    TMP.Add(new NetNodeContainer() { layer = (uint)NodesLayers.Count,
                        Weights = null
                    });
                }
                Out.Add(TMP);

            }

            List<double> Generate_RND_Weights(uint amount)
            {
                List<double> Out = new List<double>();
                Random r = new Random();
                for(int i = 0; i < amount; i++)
                {
                    Out.Add(r.Next());
                }
                return Out;
            }
            
        }
        
        class NetNodeContainer
        {
           public uint layer;
           public List<double> Weights; //The way neural nets function is by changing weights from and to each node
           public double LastOutput;
        }

        static double Sigmoid(double inp)
        {
            return (1 / (1 + Math.Exp(inp)));
        }

        static double SUM(List<double> inp)
        {
            double outp = 0;
            foreach(double dub in inp)
            {
                outp += dub;
            }
            return outp;
        }
    }
}
