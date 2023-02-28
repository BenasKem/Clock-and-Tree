
using System.ComponentModel.Design.Serialization;
using Tree;
/****************************************************************************************/

// case scenario:
//              1
//             / \
//           2     3
//          /     /|\
//         4     5 6 7
//              /  /\
//             8  9  10
//                |   
//                11     

// this was harder for me to solve, as there were no values in the tree nodes to compare (left or right tree)
// therefore, i assigned how many nodes each other node has:
// the below structure can be read as this:
// structure[index] = how many children does a node has:
//              2
//             / \
//           1     3
//          /     /|\
//         0     1 2 0
//              /  /\
//             0  1  0
//                |   
//                0     
/****************************************************************************************/



// also created the completed nodes list to check for correct indexing
List<int> completed_nodes= new List<int>();
// root node has 2 children
const int root_index = 0;


// Task Case:
int[] task_structure = {2,1,0,3,1,0,2,1,0,0,0};

Branch tree = new Branch();
tree = CreateTree(tree, root_index, task_structure, ref completed_nodes);

Console.WriteLine($"Depth of tree is {CalculateTreeDepth(tree)}");

/****************************************************************************************/
// other case scenario:
//              1
//             / \
//           2     3
//          /     /|\
//         4     5 6 7
//        /     
//       8
//      / \
//     9   10
//           \
//           11
/****************************************************************************************/

int[] example_structure = { 2,1,1,2,0,1,0,3,0,0,0};

Branch tree2 = new Branch();
tree2 = CreateTree(tree, root_index, example_structure, ref completed_nodes);

Console.WriteLine($"Depth of tree2 is {CalculateTreeDepth(tree2)}");



Branch CreateTree(Branch node, int index, int[] structure, ref List<int> traversed_nodes)
{
    traversed_nodes.Add(index);
    node.branches = new List<Branch>();
    int children = structure[index];

    // if we finished the tree
    if (index == structure.Length - 1)
    {
        traversed_nodes.Clear();
        return node;
    }

    for (int i = 1; i <= children; i++)
    {
        // if leaf node, end of branch
        if (structure[index] == 0)
            break;

        node.branches.Add( new Branch());
        // this helps to jump back from leaves to children
        
        CreateTree(node.branches[i - 1], traversed_nodes.Count(), structure, ref traversed_nodes);   
    }

 
    return node;
}


int CalculateTreeDepth(Branch branch)
{
    // base case: if branch is a leaf, return 1
    if (branch.branches.Count == 0)
    {
        return 1;
    }

    int depth = 0;
    foreach (Branch node in branch.branches)
    {
        int subDepth = CalculateTreeDepth(node);
        if (subDepth > depth)
            depth = subDepth;
    }

    return depth + 1;
}