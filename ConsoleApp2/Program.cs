// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Graph graph = new Graph();
Random random = new Random();

for (int i = 0; i < 10; i++) {
    graph.add(random.Next(0,100), graph);
}
Console.WriteLine(graph.ToString());

graph.traverse_depth(graph);


//graph.left= new Graph<int>(new Graph<int>(2), new Graph<int>(3));
//Graph<int> graph2 = graph.left;


Console.WriteLine(graph.ToString());
//Console.WriteLine(graph.left.ToString());
graph.traverse_width(graph);


class Graph
{
    public int? head;
    public Graph? left;
    public Graph? right;


    public Graph add(int value, Graph graph) {
        if (graph.head==null) { graph.head = value; return graph; }
        if (value == graph.head) { Console.WriteLine("Значение находится в графе"); return graph; }
        if (graph.head > value) { graph.left = graph.add(value, graph.left != null ? graph.left : new Graph()); }
            else { graph.right=graph.add(value, graph.right != null ? graph.right : new Graph()); }
        return graph;
        }

    public void traverse_depth(Graph graph)
    {
        if (graph.head == null) { Console.WriteLine("Пустой граф");}
        else { 
        Stack<Graph> stack = new Stack<Graph>();
        while (true) {

                if (graph.right != null) { stack.Push(graph.right); }
                if (graph.left != null) { stack.Push(graph.left); }
                Console.WriteLine(graph.head); 
                if (stack.Count==0) { break; }
                graph = stack.Pop();
        }
        }

    }
    public void traverse_width(Graph graph)
    {
        if (graph.head == null) { Console.WriteLine("Пустой граф"); }
        else
        {
            Queue<Graph> stack = new Queue<Graph>();
            while (true)
            {
                if (graph.left != null) { stack.Enqueue(graph.left); }
                if (graph.right != null) { stack.Enqueue(graph.right); }
                Console.WriteLine(graph.head);
                if (stack.Count == 0) { break; }
                graph = stack.Dequeue();
            }
        }

    }

    public override String ToString() {

        return String.Format("Head {0}, left {1}, right {2}", head != null ? head : "empty", left!=null?left:"empty", right!=null?right:"empty");
    
    }

}