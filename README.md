# Behavior_Cup

## Description
Behavior Cup is a Unity framework designed to facilitate the implementation and usage of Behavior Trees within Unity projects. It utilizes Unity's GraphView APIs to create an intuitive environment for constructing and managing Behavior trees.

## Usage
Behavior Cup simplifies the process of integrating Behavior Trees into your Unity projects. Below are some essential steps to get started:

<br>

<details>
<summary><b>Applying Steps</b></summary>
<br>
  
1. **Create a Behavior Tree**: In your project file, navigate to `Create > Behavior Tree`.
2. **Access the Editor Window**: Double-click on the created tree to open the editor window.
3. **Edit Your Tree**: Utilize custom nodes or built-in nodes to design and configure your Behavior tree.
4. **Attach the Tree to a GameObject**: In your scene, attach a `BehaviorTreeRunner` component to a GameObject and add your created Behavior tree to it.
5. **Play and Enjoy**: Press play in the Unity Editor and witness your designed Behavior tree in action within your scene.
6. **Observe and Iterate**: Analyze the Behavior of your agents or AI in the scene, iterate on the tree as needed to refine their actions.

---
</details>

<br>

<details>
<summary><b>How to Make a New Node</b></summary>
To create a new node:
<br><br>

1. **Inherit from Existing Node Class**: Within the `Behavior_Cup` namespace, inherit from one of the existing Node classes such as `ActionNode`, `CompositeNode`, or `DecoratorNode`.
2. **Apply Overrides**: Implement and override the necessary voids or methods as required by the selected node type.
3. **Start Coding Your Node**: Begin coding and defining the logic for your custom node within the inherited class.

Here is a basic example of creating a new action node:

```csharp
using Behavior_Cup;

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
The nodes in Behavior Cup have access to the blackboard instance for data sharing. Use the following APIs within your node scripts to interact with the blackboard:
<br><br>
  
```csharp
// Setting values in the blackboard from within a node
blackboard.SetComponent(key, value);
blackboard.SetFloat(key, value);
blackboard.SetInt(key, value);
blackboard.SetString(key, value);
blackboard.SetVector2(key, value);
blackboard.SetVector3(key, value);
blackboard.SetColor(key, value);
blackboard.SetBool(key, value);
blackboard.SetGradient(key, value);
blackboard.SetSprite(key, value);
```
```csharp
// Getting values from the blackboard within a node
blackboard.GetComponent<type>(key);
blackboard.GetFloat(key);
blackboard.GetInt(key);
blackboard.GetString(key);
blackboard.GetVector2(key);
blackboard.GetVector3(key);
blackboard.GetColor(key);
blackboard.GetBool(key);
blackboard.GetGradient(key);
blackboard.GetSprite(key);
```

---
</details>
<br>

<details>
<summary><b>Video Tutorial on Behavior Cup's</b></summary>
<br>
  
- 🔗 **[How to use Behavior Cup tutorial video here](#)**
- 🔗 **[Built-in Nodes tutorial video here](#)**

---
</details>
<br>

## Support
For any inquiries or support related to Behavior Cup, please contact me via email at Info@AlaaAbusarah.com

## Feedback

I would love to hear your feedback on using Behavior Cup! Please take a moment to fill out our feedback form and share your thoughts, suggestions, or any issues you encountered while testing the framework:

📝 **[Behavior Cup Feedback Form](YOUR_GOOGLE_FORM_LINK_HERE)**

Thank you for testing Behavior Cup! Your feedback is valuable in improving the framework.

## License
Behavior Cup is currently open source. The specific license details will be updated soon.
