The Netstack Language - Overview
=============

Netstack is a small, stack-based programming language.
It is based around the concept of functions taking arguments from
the stack and pushing their results onto it.


Functions
-------------
In Netstack, everything you write is a function. Literals are internally 
represented as functions that take no arguments and always return the same value.
Statements are simply functions containing other functions: 
a statement contains a sequence of functions and/or inner statements that 
will get executed in a left-to-right order, with each function modifying the data 
currently on the stack. When all functions have finished executing, 
the data left on the stack is the result of the statement's execution. 
A REPL would usually print this result to the console.


Standard Library
-------------
Netstack has a small standard library containing all functions used by the language.
these functions can be found in the `Netstack.Language.Framework` namespace.

Statements
-------------
A statement is a sequence that may contain any number of functions and
statements, which are called inner statements. What's unique about statements
is that executing them only pushes them to the top of the stack.
When you write a piece of code containing multiple statements, they will not be
executed as soon as they are encountered.

To execute the code within a statement, it must be evaluated. This is how control
statements work. An if-statement, for instance, is preceded by one statement
which gets executed when the condition evaluates to true, one for when it evaluates
to false, and one statement that's evaluated to produce the if-statement's condition,
like so:

	(true-statement) (false-statement) (condition) if

When the runtime reaches these statements, they will all get pushed on the stack
without being evaluated. Then (condition) is evaluated to determine whether 
(true-statement) or (false-statement) should be evaluated next.

A statement may also be evaluated manually, using the `eval` command, which 
pulls a statement from the top of the stack and evaluates it.


Literals
-------------
A literal is a function that always generates the same output. The parser will 
usually translate specific character sequences into literals.
For instance, the following character sequences will get translated into literals

- "Hello World!"	| string literal
- 55				| integer literal
- True				| boolean literal
- .square			| function label
- square			| late binding function call

The first three should be fairly obvious. 
The last two are covered in the next chapter.


User-defined functions
-------------
During the parsing stage, standard library functions are directly inserted into the
position where they are called.
This however, is not possible for user-defined functions, because at the position
where they are called, they may not be defined yet. In fact, their definitions
may even change at runtime, and so it is not possible to insert a user-defined 
function directly into their calling position.

Because of this, all calls to unknown functions are replaced with 
late binding function calls, which are internally considered to be literals,
because their function label never changes, and the data they contain
(their function label) comes from user-entered code.

Upon execution, a late binding function call will fetch the body for the function
assigned to their label from the function table, push it to the stack, and execute it.


Aliases
-------------
An alias is a shorthand character sequence that can be used instead of a 
function call. The interpreter internally translates aliases to function
calls before executing the application. The aliases available in Netstack are:

alias|function
-----|--------
+  | add
-  | subtract
*  | multiply
/  | divide
++ | increment
-- | decrement
=  | equals
<  | less than
>  | greater than

It is therefore entirely possible to write

	5 5 add

instead of

	5 5 +

as they are functionally equivalent.

Also note that equality checks use a single equals sign.
If assignment is added to the language at a later point,
it will use a different operator, possibly `<-`.


Special Aliases
-------------
A special alias is a special character sequence which
is used to denote data. Special aliases are always translated into literals.

The following literals are available:

Boolean:
	Any character sequence that is either "True" or "False".
Integer:
	Any character sequence consisting only of the digits 0-9.
String:,
	Any character sequence started and terminated by a quotation mark (`"`).
	Quotation marks may be escaped by prefixing them with a `\`.



The Stack
-------------
The stack is where Netstack stores all data relevant to the application.
It can store any data type in any order.

Examples
=============

Pushes 5 on the stac, pushes 2 on the stack, then pops the topmost numbers
on the stack, adds them, producing 7, and pushes this resulting value 
back to the stack.

    5 2 +

Control functions are preceded by two statements that get executed when
the condition is true or false, and one statement that is evaluated to 
produce the condition.

	("input is greater than three")
	("input is less than three")
	(read parseint 3 > )
	if

Function definitions are preceded by a statement forming the function body
and a function label. The `defn` function maps the function label to the
function body and adds this mapping to the function table.

	(
		()
		(
			-- dup fib 
			swap 
			-- fib 
			+
		)
		(dup 2 <) if
	) .fib defn
