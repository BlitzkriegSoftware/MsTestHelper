<a name='assembly'></a>
# BlitzkriegSoftware.MsTest

## Contents

- [AssertHelpers](#T-BlitzkriegSoftware-MsTest-AssertHelpers 'BlitzkriegSoftware.MsTest.AssertHelpers')
  - [AssertSerialization\`\`1(thing1,output)](#M-BlitzkriegSoftware-MsTest-AssertHelpers-AssertSerialization``1-``0,Microsoft-VisualStudio-TestTools-UnitTesting-TestContext- 'BlitzkriegSoftware.MsTest.AssertHelpers.AssertSerialization``1(``0,Microsoft.VisualStudio.TestTools.UnitTesting.TestContext)')
- [MsTestLogger\`1](#T-BlitzkriegSoftware-MsTest-MsTestLogger`1 'BlitzkriegSoftware.MsTest.MsTestLogger`1')
  - [#ctor(output)](#M-BlitzkriegSoftware-MsTest-MsTestLogger`1-#ctor-Microsoft-VisualStudio-TestTools-UnitTesting-TestContext- 'BlitzkriegSoftware.MsTest.MsTestLogger`1.#ctor(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext)')
  - [BeginScope\`\`1(state)](#M-BlitzkriegSoftware-MsTest-MsTestLogger`1-BeginScope``1-``0- 'BlitzkriegSoftware.MsTest.MsTestLogger`1.BeginScope``1(``0)')
  - [Dispose()](#M-BlitzkriegSoftware-MsTest-MsTestLogger`1-Dispose 'BlitzkriegSoftware.MsTest.MsTestLogger`1.Dispose')
  - [IsEnabled(logLevel)](#M-BlitzkriegSoftware-MsTest-MsTestLogger`1-IsEnabled-Microsoft-Extensions-Logging-LogLevel- 'BlitzkriegSoftware.MsTest.MsTestLogger`1.IsEnabled(Microsoft.Extensions.Logging.LogLevel)')
  - [Log\`\`1(logLevel,eventId,state,exception,formatter)](#M-BlitzkriegSoftware-MsTest-MsTestLogger`1-Log``1-Microsoft-Extensions-Logging-LogLevel,Microsoft-Extensions-Logging-EventId,``0,System-Exception,System-Func{``0,System-Exception,System-String}- 'BlitzkriegSoftware.MsTest.MsTestLogger`1.Log``1(Microsoft.Extensions.Logging.LogLevel,Microsoft.Extensions.Logging.EventId,``0,System.Exception,System.Func{``0,System.Exception,System.String})')
- [TestJsonSerializationHelper](#T-BlitzkriegSoftware-MsTest-TestJsonSerializationHelper 'BlitzkriegSoftware.MsTest.TestJsonSerializationHelper')
  - [AssertJsonSerialization\`\`1(thing1,testContext)](#M-BlitzkriegSoftware-MsTest-TestJsonSerializationHelper-AssertJsonSerialization``1-Microsoft-VisualStudio-TestTools-UnitTesting-TestContext,``0- 'BlitzkriegSoftware.MsTest.TestJsonSerializationHelper.AssertJsonSerialization``1(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext,``0)')
- [TestOutputHelper](#T-BlitzkriegSoftware-MsTest-TestOutputHelper 'BlitzkriegSoftware.MsTest.TestOutputHelper')
  - [AsJson(output,o,title)](#M-BlitzkriegSoftware-MsTest-TestOutputHelper-AsJson-Microsoft-VisualStudio-TestTools-UnitTesting-TestContext,System-Object,System-String- 'BlitzkriegSoftware.MsTest.TestOutputHelper.AsJson(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext,System.Object,System.String)')
- [TxTimer](#T-BlitzkriegSoftware-MsTest-TxTimer 'BlitzkriegSoftware.MsTest.TxTimer')
  - [#ctor()](#M-BlitzkriegSoftware-MsTest-TxTimer-#ctor 'BlitzkriegSoftware.MsTest.TxTimer.#ctor')
  - [#ctor(testContext)](#M-BlitzkriegSoftware-MsTest-TxTimer-#ctor-Microsoft-VisualStudio-TestTools-UnitTesting-TestContext- 'BlitzkriegSoftware.MsTest.TxTimer.#ctor(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext)')
  - [ElapsedMilliseconds](#P-BlitzkriegSoftware-MsTest-TxTimer-ElapsedMilliseconds 'BlitzkriegSoftware.MsTest.TxTimer.ElapsedMilliseconds')
  - [ElaspsedTicks](#P-BlitzkriegSoftware-MsTest-TxTimer-ElaspsedTicks 'BlitzkriegSoftware.MsTest.TxTimer.ElaspsedTicks')
  - [IsRunning](#P-BlitzkriegSoftware-MsTest-TxTimer-IsRunning 'BlitzkriegSoftware.MsTest.TxTimer.IsRunning')
  - [StopWatch](#P-BlitzkriegSoftware-MsTest-TxTimer-StopWatch 'BlitzkriegSoftware.MsTest.TxTimer.StopWatch')
  - [Cancel()](#M-BlitzkriegSoftware-MsTest-TxTimer-Cancel 'BlitzkriegSoftware.MsTest.TxTimer.Cancel')
  - [DisplayElaspsedTime(milliseconds)](#M-BlitzkriegSoftware-MsTest-TxTimer-DisplayElaspsedTime-System-Int64- 'BlitzkriegSoftware.MsTest.TxTimer.DisplayElaspsedTime(System.Int64)')
  - [DisplayElaspsedTime(ts)](#M-BlitzkriegSoftware-MsTest-TxTimer-DisplayElaspsedTime-System-TimeSpan- 'BlitzkriegSoftware.MsTest.TxTimer.DisplayElaspsedTime(System.TimeSpan)')
  - [Dispose()](#M-BlitzkriegSoftware-MsTest-TxTimer-Dispose 'BlitzkriegSoftware.MsTest.TxTimer.Dispose')
  - [Reset()](#M-BlitzkriegSoftware-MsTest-TxTimer-Reset 'BlitzkriegSoftware.MsTest.TxTimer.Reset')
  - [Start()](#M-BlitzkriegSoftware-MsTest-TxTimer-Start 'BlitzkriegSoftware.MsTest.TxTimer.Start')
  - [Stop()](#M-BlitzkriegSoftware-MsTest-TxTimer-Stop 'BlitzkriegSoftware.MsTest.TxTimer.Stop')

<a name='T-BlitzkriegSoftware-MsTest-AssertHelpers'></a>
## AssertHelpers `type`

##### Namespace

BlitzkriegSoftware.MsTest

##### Summary

Helpers to do asserts on objects in bulk

<a name='M-BlitzkriegSoftware-MsTest-AssertHelpers-AssertSerialization``1-``0,Microsoft-VisualStudio-TestTools-UnitTesting-TestContext-'></a>
### AssertSerialization\`\`1(thing1,output) `method`

##### Summary

Tests that a model serializes correctly

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| thing1 | [\`\`0](#T-``0 '``0') | Instance of T to test |
| output | [Microsoft.VisualStudio.TestTools.UnitTesting.TestContext](#T-Microsoft-VisualStudio-TestTools-UnitTesting-TestContext 'Microsoft.VisualStudio.TestTools.UnitTesting.TestContext') | TestContext |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type |

<a name='T-BlitzkriegSoftware-MsTest-MsTestLogger`1'></a>
## MsTestLogger\`1 `type`

##### Namespace

BlitzkriegSoftware.MsTest

##### Summary

ILogger for MsTest

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-BlitzkriegSoftware-MsTest-MsTestLogger`1-#ctor-Microsoft-VisualStudio-TestTools-UnitTesting-TestContext-'></a>
### #ctor(output) `constructor`

##### Summary

CTOR

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| output | [Microsoft.VisualStudio.TestTools.UnitTesting.TestContext](#T-Microsoft-VisualStudio-TestTools-UnitTesting-TestContext 'Microsoft.VisualStudio.TestTools.UnitTesting.TestContext') | TestContext |

<a name='M-BlitzkriegSoftware-MsTest-MsTestLogger`1-BeginScope``1-``0-'></a>
### BeginScope\`\`1(state) `method`

##### Summary

Begin Scope

##### Returns

this

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| state | [\`\`0](#T-``0 '``0') | TState |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TState |  |

<a name='M-BlitzkriegSoftware-MsTest-MsTestLogger`1-Dispose'></a>
### Dispose() `method`

##### Summary

Dispose (DTOR)

##### Parameters

This method has no parameters.

<a name='M-BlitzkriegSoftware-MsTest-MsTestLogger`1-IsEnabled-Microsoft-Extensions-Logging-LogLevel-'></a>
### IsEnabled(logLevel) `method`

##### Summary

IsEnabled

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logLevel | [Microsoft.Extensions.Logging.LogLevel](#T-Microsoft-Extensions-Logging-LogLevel 'Microsoft.Extensions.Logging.LogLevel') |  |

<a name='M-BlitzkriegSoftware-MsTest-MsTestLogger`1-Log``1-Microsoft-Extensions-Logging-LogLevel,Microsoft-Extensions-Logging-EventId,``0,System-Exception,System-Func{``0,System-Exception,System-String}-'></a>
### Log\`\`1(logLevel,eventId,state,exception,formatter) `method`

##### Summary

Log (Contract method)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logLevel | [Microsoft.Extensions.Logging.LogLevel](#T-Microsoft-Extensions-Logging-LogLevel 'Microsoft.Extensions.Logging.LogLevel') | LogLevel |
| eventId | [Microsoft.Extensions.Logging.EventId](#T-Microsoft-Extensions-Logging-EventId 'Microsoft.Extensions.Logging.EventId') | EventId |
| state | [\`\`0](#T-``0 '``0') | TState |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Exception |
| formatter | [System.Func{\`\`0,System.Exception,System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Exception,System.String}') | Function Formatter |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TState | TState |

<a name='T-BlitzkriegSoftware-MsTest-TestJsonSerializationHelper'></a>
## TestJsonSerializationHelper `type`

##### Namespace

BlitzkriegSoftware.MsTest

##### Summary

An Extension to use the helper from TestContext

<a name='M-BlitzkriegSoftware-MsTest-TestJsonSerializationHelper-AssertJsonSerialization``1-Microsoft-VisualStudio-TestTools-UnitTesting-TestContext,``0-'></a>
### AssertJsonSerialization\`\`1(thing1,testContext) `method`

##### Summary

Tests that a model serializes correctly, will fail the internal `Assert` if not.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| thing1 | [Microsoft.VisualStudio.TestTools.UnitTesting.TestContext](#T-Microsoft-VisualStudio-TestTools-UnitTesting-TestContext 'Microsoft.VisualStudio.TestTools.UnitTesting.TestContext') | Instance of T to test |
| testContext | [\`\`0](#T-``0 '``0') | TestContext |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type |

<a name='T-BlitzkriegSoftware-MsTest-TestOutputHelper'></a>
## TestOutputHelper `type`

##### Namespace

BlitzkriegSoftware.MsTest

##### Summary

Helper to output as JSON

<a name='M-BlitzkriegSoftware-MsTest-TestOutputHelper-AsJson-Microsoft-VisualStudio-TestTools-UnitTesting-TestContext,System-Object,System-String-'></a>
### AsJson(output,o,title) `method`

##### Summary

Emit an object as json

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| output | [Microsoft.VisualStudio.TestTools.UnitTesting.TestContext](#T-Microsoft-VisualStudio-TestTools-UnitTesting-TestContext 'Microsoft.VisualStudio.TestTools.UnitTesting.TestContext') | ITestOutputHelper |
| o | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | object |
| title | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (optional) Title |

<a name='T-BlitzkriegSoftware-MsTest-TxTimer'></a>
## TxTimer `type`

##### Namespace

BlitzkriegSoftware.MsTest

##### Summary

Handy Helper to Time Executions of Tests

Here is a typical snippet, because the class supports [IDisposable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IDisposable 'System.IDisposable') the time can be started at the top 
of the using statement and automatically stopped in the dispose

```
// Stop Watch Created and Started
using (FcTimer myTimer = new FcTimer( ... )) {
    // Do something you want timed
    var elapsed = myTimer.ElapsedMilliseconds;
    // Stop Watch stopped in DTOR
}
```

<a name='M-BlitzkriegSoftware-MsTest-TxTimer-#ctor'></a>
### #ctor() `constructor`

##### Summary

CTOR

Also starts timer

##### Parameters

This constructor has no parameters.

<a name='M-BlitzkriegSoftware-MsTest-TxTimer-#ctor-Microsoft-VisualStudio-TestTools-UnitTesting-TestContext-'></a>
### #ctor(testContext) `constructor`

##### Summary

CTOR with optional injection of TestContext

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| testContext | [Microsoft.VisualStudio.TestTools.UnitTesting.TestContext](#T-Microsoft-VisualStudio-TestTools-UnitTesting-TestContext 'Microsoft.VisualStudio.TestTools.UnitTesting.TestContext') |  |

<a name='P-BlitzkriegSoftware-MsTest-TxTimer-ElapsedMilliseconds'></a>
### ElapsedMilliseconds `property`

##### Summary

Returns milliseconds from a running timer

<a name='P-BlitzkriegSoftware-MsTest-TxTimer-ElaspsedTicks'></a>
### ElaspsedTicks `property`

##### Summary

Returns the elapsed ticks from a running timer

<a name='P-BlitzkriegSoftware-MsTest-TxTimer-IsRunning'></a>
### IsRunning `property`

##### Summary

Determine if the stop watch is running

<a name='P-BlitzkriegSoftware-MsTest-TxTimer-StopWatch'></a>
### StopWatch `property`

##### Summary

Stop watch instance

Do not access directly if possible

<a name='M-BlitzkriegSoftware-MsTest-TxTimer-Cancel'></a>
### Cancel() `method`

##### Summary

Stop and destroy the timer

##### Parameters

This method has no parameters.

<a name='M-BlitzkriegSoftware-MsTest-TxTimer-DisplayElaspsedTime-System-Int64-'></a>
### DisplayElaspsedTime(milliseconds) `method`

##### Summary

Display milliseconds in a nice string

##### Returns

nice string

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| milliseconds | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | milliseconds |

<a name='M-BlitzkriegSoftware-MsTest-TxTimer-DisplayElaspsedTime-System-TimeSpan-'></a>
### DisplayElaspsedTime(ts) `method`

##### Summary

Display TimeSpan in a nice string

##### Returns

nice string

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ts | [System.TimeSpan](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.TimeSpan 'System.TimeSpan') | TimeSpan |

<a name='M-BlitzkriegSoftware-MsTest-TxTimer-Dispose'></a>
### Dispose() `method`

##### Summary

Generic destructor

##### Parameters

This method has no parameters.

<a name='M-BlitzkriegSoftware-MsTest-TxTimer-Reset'></a>
### Reset() `method`

##### Summary

Reset but do not destroy the timer

##### Parameters

This method has no parameters.

<a name='M-BlitzkriegSoftware-MsTest-TxTimer-Start'></a>
### Start() `method`

##### Summary

Called by constructor, creates a new stop watch and starts it
Try not to call explictly

##### Parameters

This method has no parameters.

<a name='M-BlitzkriegSoftware-MsTest-TxTimer-Stop'></a>
### Stop() `method`

##### Summary

Called by destructor, stops stopwatch writes log (optionally)

##### Returns

Milliseconds Elapsed

##### Parameters

This method has no parameters.
