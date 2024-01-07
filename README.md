# Behaviour_Cup

## Description
Behaviour Cup is a Unity framework designed to facilitate the implementation and usage of Behaviour Trees within Unity projects. It utilizes Unity's GraphView APIs to create an intuitive environment for constructing and managing Behaviour trees.

## Usage
Behaviour Cup simplifies the process of integrating Behaviour Trees into your Unity projects. Below are some essential steps to get started:

<br>

<details>
<summary><b>Applying Steps</b></summary>
<br>
  
1. **Create a Behaviour Tree**: In your project file, navigate to `Create > Behaviour Tree`.
2. **Access the Editor Window**: Double-click on the created tree to open the editor window.
3. **Edit Your Tree**: Utilize custom nodes or built-in nodes to design and configure your Behaviour tree.
4. **Attach the Tree to a GameObject**: In your scene, attach a `BehaviourTreeRunner` component to a GameObject and add your created Behaviour tree to it.
5. **Play and Enjoy**: Press play in the Unity Editor and witness your designed Behaviour tree in action within your scene.
6. **Observe and Iterate**: Analyze the Behaviour of your agents or AI in the scene, iterate on the tree as needed to refine their actions.

---
</details>

<br>

<details>
<summary><b>How to Make a New Node</b></summary>
To create a new node:
<br><br>

1. **Inherit from Existing Node Class**: Within the `Behaviour_Cup` namespace, inherit from one of the existing Node classes such as `ActionNode`, `CompositeNode`, or `DecoratorNode`.
2. **Apply Overrides**: Implement and override the necessary voids or methods as required by the selected node type.
3. **Start Coding Your Node**: Begin coding and defining the logic for your custom node within the inherited class.

Here is a basic example of creating a new action node:

```csharp
using Behaviour_Cup;

    public class CustomActionNode : ActionNode
    {
        /// <summary>
        /// Get call when first start run the node.
        /// </summary>
        protected override void OnStart() { }

        /// <summary>
        /// Get call when exit the node.
        /// </summary>
        protected override void OnStop() { }

        /// <summary>
        /// Get call every frame when node is running.
        /// </summary>
        /// <returns>The current state of the node</returns>
        protected override State OnUpdate() { return State.Success; }
    }
```

---
</details>

<br>

<details>
<summary><b>How to Use the Blackboard within Nodes</b></summary>
The nodes in Behaviour Cup have access to the blackboard instance for data sharing. Use the following APIs within your node scripts to interact with the blackboard:
<br><br>
  
```csharp
// Setting values in the blackboard from within a node
blackboard.Set_[ListName](key, value);
```
```csharp
// Getting values from the blackboard within a node
blackboard.Get_[ListName](key);
```

---
</details>
<br>

<details>
<summary><b>Video Tutorial on Behaviour Cup's</b></summary>
<br>
  
- 🔗 **[How to use Behaviour Cup tutorial video](https://youtu.be/i_TRpT_5C1E)**
- 🔗 **[Built-in Nodes tutorial video](https://youtu.be/9lafxmoEiTg)**
  
---
</details>
<br>

## Support
For any inquiries or support related to Behaviour Cup, please contact me via email at Info@AlaaAbusarah.com

## Feedback

I would love to hear your feedback on using Behaviour Cup! Please take a moment to fill out our feedback form and share your thoughts, suggestions, or any issues you encountered while testing the framework:

📝 **[Behaviour Cup Feedback Form](https://forms.gle/W8PjAkRnwZd4Yzzi6)**

Thank you for testing Behaviour Cup! Your feedback is valuable in improving the framework.

## License
Behaviour Cup is currently open source. The specific license details will be updated soon.
