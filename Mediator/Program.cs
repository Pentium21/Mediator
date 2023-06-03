using System;

// Интерфейс для компонентов робота
interface IRobotComponent
{
    void DoTask(string task);
    void SetMediator(RobotMediator mediator);
}

// Конкретные компоненты робота
class Motor : IRobotComponent
{
    private RobotMediator mediator;

    public void DoTask(string task)
    {
        Console.WriteLine("Motor did task: " + task);
    }

    public void SetMediator(RobotMediator mediator)
    {
        this.mediator = mediator;
    }
}

class Sensor : IRobotComponent
{
    private RobotMediator mediator;

    public void DoTask(string task)
    {
        Console.WriteLine("Sensor did task: " + task);
    }

    public void SetMediator(RobotMediator mediator)
    {
        this.mediator = mediator;
    }
}

class Camera : IRobotComponent
{
    private RobotMediator mediator;

    public void DoTask(string task)
    {
        Console.WriteLine("Camera did task: " + task);
    }

    public void SetMediator(RobotMediator mediator)
    {
        this.mediator = mediator;
    }
}

class Arm : IRobotComponent
{
    private RobotMediator mediator;

    public void DoTask(string task)
    {
        Console.WriteLine("Arm did task: " + task);
    }

    public void SetMediator(RobotMediator mediator)
    {
        this.mediator = mediator;
    }
}

// Медиатор для управления взаимодействием между компонентами робота
class RobotMediator
{
    private Motor motor;
    private Sensor sensor;
    private Camera camera;
    private Arm arm;

    public RobotMediator(Motor motor, Sensor sensor, Camera camera, Arm arm)
    {
        this.motor = motor;
        this.sensor = sensor;
        this.camera = camera;
        this.arm = arm;

        this.motor.SetMediator(this);
        this.sensor.SetMediator(this);
        this.camera.SetMediator(this);
        this.arm.SetMediator(this);
    }

    public void MoveForward()
    {
        motor.DoTask("Move forward");
    }

    public void RotateLeft()
    {
        motor.DoTask("Rotate left");
    }

    public void RotateRight()
    {
        motor.DoTask("Rotate right");
    }

    public void TakePicture()
    {
        camera.DoTask("Take picture");
    }

    public void DetectObstacle()
    {
        sensor.DoTask("Detect obstacle");
    }

    public void GrabObject()
    {
        arm.DoTask("Grab object");
    }
}

// Пример использования паттерна Mediator
class Program
{
    static void Main(string[] args)
    {
        Motor motor = new Motor();
        Sensor sensor = new Sensor();
        Camera camera = new Camera();
        Arm arm = new Arm();
        RobotMediator mediator = new RobotMediator(motor, sensor, camera, arm);

        mediator.MoveForward();
        mediator.RotateLeft();
        mediator.RotateRight();
        mediator.TakePicture();
        mediator.DetectObstacle();
        mediator.GrabObject();
    }
}