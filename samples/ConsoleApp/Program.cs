using DotNetGraph;
using DotNetGraph.Edge;
using DotNetGraph.Extensions;
using Shirhatti.Graphviz;
using System;
using System.IO;

DotGraph graph = new DotGraph("graph");
DotEdge myEdge = new DotEdge("myNode1", "myNode2");
graph.Elements.Add(myEdge);
string dot = graph.Compile();

// You can specify a dot string directly instead
// var dot = "digraph D { A-> { B, C, D} -> { F} }";

using Graphviz graphviz = new Graphviz();
using Cgraph cgraph = new Cgraph(dot);
byte[] image = graphviz.RenderDot(cgraph, OutputFormat.Svg);

Console.WriteLine(graphviz.BuildDate);
Console.WriteLine(graphviz.Version);

File.WriteAllBytes("image.svg", image);
