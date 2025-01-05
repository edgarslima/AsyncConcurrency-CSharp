# AsyncConcurrency-CSharp

This project explores various execution and concurrency approaches in C#, including synchronous, asynchronous, and parallel asynchronous methods.

## Description

The aim is to present practical examples demonstrating how to implement and utilize three types of execution in C#:

- **Synchronous Execution:** Tasks are performed one after the other, sequentially, causing the application to become unresponsive until execution completes.

- **Asynchronous Execution:** Tasks begin and allow others to execute while awaiting their completion, enhancing efficiency in input/output operations and preventing application freezes. However, the total execution time remains the sum of all tasks.

- **Parallel Asynchronous Execution:** Multiple asynchronous tasks run simultaneously, leveraging system resources to boost performance. This approach keeps the application responsive, with all tasks processed concurrently. In this scenario, the execution time is determined by the longest-running task, significantly reducing the overall execution time.

## How to Run the Project

1. **Clone the repository:**

```bash
git clone https://github.com/edgarslima/AsyncConcurrency-CSharp.git
```