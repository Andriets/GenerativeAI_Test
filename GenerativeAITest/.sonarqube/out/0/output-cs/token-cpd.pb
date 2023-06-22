�
[D:\Study\SoftServe\Generative AI Test\GenerativeAITest\Controllers\TransactionController.cs
	namespace 	
GenerativeAITest
 
. 
Controllers &
{ 
[ 

] 
[ 
Route 

(
 
$str 
) 
] 
public 

class !
TransactionController &
:' (
ControllerBase) 7
{		 
private

 
readonly

 
IConfiguration

 '
_configuration

( 6
;

6 7
public !
TransactionController $
($ %
IConfiguration% 3

)A B
{
_configuration 
= 

;* +
} 	
[ 	
HttpGet	 
] 
[ 	
Route	 
( 
$str 
)  
]  !
public 

GetListBalance +
(+ ,
), -
{ 	
try 
{ 
var 
stripeApiKey  
=! "
_configuration# 1
[1 2
$str2 E
]E F
;F G
StripeConfiguration #
.# $
ApiKey$ *
=+ ,
stripeApiKey- 9
;9 :
var 
balanceService "
=# $
new% (
BalanceService) 7
(7 8
)8 9
;9 :
var 
balance 
= 
balanceService ,
., -
Get- 0
(0 1
)1 2
;2 3
return 
Ok 
( 
balance !
)! "
;" #
} 
catch 
( 
	Exception 
ex !
)! "
{ 
return   

BadRequest   !
(  ! "
ex  " $
.  $ %
Message  % ,
)  , -
;  - .
}!! 
}## 	
}$$ 
}%% �
AD:\Study\SoftServe\Generative AI Test\GenerativeAITest\Program.cs
var 
builder 
= 
WebApplication 
. 

(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
var 
app 
= 	
builder
 
. 
Build 
( 
) 
; 
app 
. 

UseRouting 
( 
) 
; 
app		 
.		 
UseEndpoints		 
(		 
	endpoints		 
=>		 
{

 
	endpoints 
.
MapControllers 
( 
) 
; 
} 
) 
; 
app 
. 
Run 
( 
) 	
;	 