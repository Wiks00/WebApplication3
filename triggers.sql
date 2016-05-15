--------------------------------------------------------
--  File created - воскресенье-мая-15-2016   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Trigger BASCKET_UNIQUE_ROW
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "WIKS"."BASCKET_UNIQUE_ROW" 
before insert on BASCKET
for EACH row
declare
   new_id NUMBER ;
begin  

    if :new.BASCKETID is null or  :new.BASCKETID = 0 then
    select ID_BASCKET_SEQUENCE.nextval into :new.BASCKETID from dual;
    end if;   

end;
/
ALTER TRIGGER "WIKS"."BASCKET_UNIQUE_ROW" ENABLE;
--------------------------------------------------------
--  DDL for Trigger USERINF_UNIQUE_ROW
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "WIKS"."USERINF_UNIQUE_ROW" 
before insert on USERINF
for EACH row
declare
   new_id NUMBER ;
begin  

    if :new.USERINFID is null or :new.USERINFID = 0 then
    select ID_USERINF_SEQUENCE.nextval into :new.USERINFID from dual;
    end if;
  

end;
/
ALTER TRIGGER "WIKS"."USERINF_UNIQUE_ROW" ENABLE;
--------------------------------------------------------
--  DDL for Trigger CATEGORIES_UNIQUE_ROW
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "WIKS"."CATEGORIES_UNIQUE_ROW" 
before insert on CATEGORIES
for EACH row
declare
   new_id NUMBER ;
begin  

    if :new.CATEGORYID is null or :new.CATEGORYID = 0 then
    select ID_CATEGORIES_SEQUENCE.nextval into :new.CATEGORYID from dual;
    end if;
   

end;
/
ALTER TRIGGER "WIKS"."CATEGORIES_UNIQUE_ROW" ENABLE;
--------------------------------------------------------
--  DDL for Trigger GUEST_UNIQUE_ROW
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "WIKS"."GUEST_UNIQUE_ROW" 
before insert on GUEST
for EACH row
declare
   new_id NUMBER ;
begin  
  Select count(GUESTID) into new_id from GUEST where GUESTID = :new.GUESTID;
  
  if new_id = 0 then
    if :new.GUESTID is null then
    select ID_GUEST_SEQUENCE.nextval into :new.GUESTID from dual;
    end if;
  else
    DBMS_OUTPUT.PUT_LINE('id:'||:new.GUESTID||'invalid');
  end if;    

end;
/
ALTER TRIGGER "WIKS"."GUEST_UNIQUE_ROW" ENABLE;
--------------------------------------------------------
--  DDL for Trigger ITEMINBASCKET_UNIQUE_ROW
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "WIKS"."ITEMINBASCKET_UNIQUE_ROW" 
before insert on ITEMINBASCKET
for EACH row
declare
   new_id NUMBER ;
begin  

    if :new.ITEMINBASCKETID is null or  :new.ITEMINBASCKETID = 0 then
    select ID_ITEMINBASCKET_SEQUENCE.nextval into :new.ITEMINBASCKETID from dual;
    end if;
 

end;
/
ALTER TRIGGER "WIKS"."ITEMINBASCKET_UNIQUE_ROW" ENABLE;
--------------------------------------------------------
--  DDL for Trigger ITEMORDER_UNIQUE_ROW
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "WIKS"."ITEMORDER_UNIQUE_ROW" 
before insert on ITEMORDER
for EACH row
declare
   new_id NUMBER ;
begin  

    if :new.ITEMORDERID is null or :new.ITEMORDERID = 0 then
    select ID_ITEMORDER_SEQUENCE.nextval into :new.ITEMORDERID from dual;
    end if;
   

end;
/
ALTER TRIGGER "WIKS"."ITEMORDER_UNIQUE_ROW" ENABLE;
--------------------------------------------------------
--  DDL for Trigger ITEMS_UNIQUE_ROW
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "WIKS"."ITEMS_UNIQUE_ROW" 
before insert on ITEMS
for EACH row
declare
   new_id NUMBER ;
begin  
    if :new.ITEMID is null or :new.ITEMID  = 0 then
    select ID_ITEMS_SEQUENCE.nextval into :new.ITEMID from dual;
    end if;

end;
/
ALTER TRIGGER "WIKS"."ITEMS_UNIQUE_ROW" ENABLE;
--------------------------------------------------------
--  DDL for Trigger ORDERS_UNIQUE_ROW
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "WIKS"."ORDERS_UNIQUE_ROW" 
before insert on ORDERS
for EACH row
declare
   new_id NUMBER ;
begin  

    if :new.ORDERID is null or :new.ORDERID = 0 then
    select ID_ORDERS_SEQUENCE.nextval into :new.ORDERID from dual;
    end if;
  

end;
/
ALTER TRIGGER "WIKS"."ORDERS_UNIQUE_ROW" ENABLE;
--------------------------------------------------------
--  DDL for Trigger MANAGERS_UNIQUE_ROW
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "WIKS"."MANAGERS_UNIQUE_ROW" 
before insert on MANAGERS
for EACH row
declare
   new_id NUMBER ;
begin  

    if :new.MANAGERID is null or :new.MANAGERID = 0 then
    select ID_MANAGERS_SEQUENCE.nextval into :new.MANAGERID from dual;
    end if;
  

end;
/
ALTER TRIGGER "WIKS"."MANAGERS_UNIQUE_ROW" ENABLE;
--------------------------------------------------------
--  DDL for Trigger PRISELIST_UNIQUE_ROW
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "WIKS"."PRISELIST_UNIQUE_ROW" 
before insert on PRISELIST
for EACH row
declare
   new_id NUMBER ;
begin  

    if :new.PRISELISTID is null or :new.PRISELISTID = 0 then
    select ID_PRISELIST_SEQUENCE.nextval into :new.PRISELISTID from dual;
    end if;
      

end;
/
ALTER TRIGGER "WIKS"."PRISELIST_UNIQUE_ROW" ENABLE;
--------------------------------------------------------
--  DDL for Trigger STOCK_UNIQUE_ROW
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "WIKS"."STOCK_UNIQUE_ROW" 
before insert on STOCK
for EACH row
declare
   new_id NUMBER ;
begin  
    if :new.STOCKID is null or :new.STOCKID  = 0 then
    select ID_STOCK_SEQUENCE.nextval into :new.STOCKID from dual;
    end if;
  

end;
/
ALTER TRIGGER "WIKS"."STOCK_UNIQUE_ROW" ENABLE;
--------------------------------------------------------
--  DDL for Trigger SUPPLIERS_UNIQUE_ROW
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "WIKS"."SUPPLIERS_UNIQUE_ROW" 
before insert on SUPPLIERS
for EACH row
declare
   new_id NUMBER ;
begin  

    if :new.SUPPLIERID is null or :new.SUPPLIERID = 0 then
    select ID_SUPPLIERS_SEQUENCE.nextval into :new.SUPPLIERID from dual;
    end if;
 

end;
/
ALTER TRIGGER "WIKS"."SUPPLIERS_UNIQUE_ROW" ENABLE;
--------------------------------------------------------
--  DDL for Trigger USERSS_UNIQUE_ROW
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "WIKS"."USERSS_UNIQUE_ROW" 
before insert on USERSS
for EACH row
declare
   new_id NUMBER ;
begin  

    if :new.USERID is null or :new.USERID = 0 then
      select ID_USERSS_SEQUENCE.nextval into :new.USERID from dual;
    end if;
  

end;
/
ALTER TRIGGER "WIKS"."USERSS_UNIQUE_ROW" ENABLE;
