--��������˰�ʺ�˰����壺������������3�·ݣ�������ҵ�������
select
b.OrderNo as '�������',
CONVERT(nvarchar(7),b.OrderTime,121) as '�·�',
c.CustName as '�ͻ�����',
REPLACE(d.SRVName,'��������','') as '��������',
a.ODUnit as '��λ',
a.ODQTY as '����',
a.ODUnitPrice as '����',
a.ODARAmount as '���',
a.ODTaxRate as '˰��',
a.ODTaxAmount as '˰��'
from Op_OrderDetail a 
left join Op_OrderHeader b on a.RefRP=b.RowPointer
left join Mstr_Customer c on b.CustNo=c.CustNo
left join Mstr_Service d on a.ODSRVNo=d.SRVNo
where CONVERT(nvarchar(7),b.OrderTime,121)='2019-03'
and b.OrderStatus>1
and a.ODContractSPNo='FWC-004'
order by b.OrderNo
--select * from Op_OrderDetail