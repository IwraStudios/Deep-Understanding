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
        
            List<uint> NodeLayout = new List<uint>();
            //TODO: make easy (test) node layout
            NetNodeContainer Net = new NetNodeContainer();
            Net.Generate_Nodes();

        }

        //Single network
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


            public void Generate_Nodes()
            {
                //Generation Structure
                //InputLayer(0)
                //HiddenLayers(1-x)
                //OutputLayer(x+1)
                //Generation Structure/
            
                //Random class for initialization
                //We won't be using "special" wieght initialization
                //Just random numbers
                Random r = new Random();
            
                //Ouput network
                List<List<NetNodeContainer>> Out = new List<List<NetNodeContainer>>();
                //Single Layer
                List<NetNodeContainer> TMP = new List<NetNodeContainer>();
                
                ///InputNodes
                for(int i = 0; i < inputAmount; i++) //Generate Output Nodes
                {
                    TMP.Add(new NetNodeContainer() { layer = 0, //InputLayer(0)
                        Weights = r.Next()//Make weights a radom number
                    });
                }
                Out.Add(TMP); //Add inputs to network
                ///InputNodes/
                
                //Generate Hidden Nodes
                for (int j = 0; j< NodesLayers.Count; j++){//for amount of layers
                    TMP = new List<NetNodeContainer>(); //Make empty
                    for (int i = 0; i < OutputAmount; i++)//Nodes of each layer
                    {
                        TMP.Add(new NetNodeContainer() { layer = (uint)NodesLayers.Count+1, //HiddenLayers(1-x)
                            Weights = r.Next()//Make weights a radom number
                        });
                    }
                    Out.Add(TMP);
                }
                
                //Generate Hidden Nodes/
                
                
                ///OutputNodes
                TMP = new List<NetNodeContainer>(); //Make empty
                for (int i = 0; i < OutputAmount; i++) //Genereate Output Nodes
                {
                    TMP.Add(new NetNodeContainer() { layer = (uint)NodesLayers.Count+1, //OutputLayer(x+1)
                        Weights = r.Next()//Make weights a radom number
                    });
                }
                Out.Add(TMP);
                ///OutputNodes/

            }
            
        }
        
        //Single Node
        class NetNodeContainer
        {
           public uint layer;
           public List<double> Weights; //The way neural nets function is by changing weights from and to each node
           public double LastOutput;
        }
        
        //Generic Sigmoid function
        static double Sigmoid(double inp)
        {
            return (1 / (1 + Math.Exp(inp)));
        }
        
        //Generic Sum function
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
