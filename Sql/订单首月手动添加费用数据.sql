select top 4 * from Op_ContractRMRentList where SRVNo in('DL-DF-1','DL-SF-1','DL-GTDF','DL-GTSF');
select  * from Op_ContractRMRentList where Creator like '%��%'
select  count(*) from Op_ContractRMRentList
--delete from Op_ContractRMRentList where Creator = '�����'
select b.RowPointer,b.ContractNo,b.ContractCreateDate,b.FeeStartDate,b.ContractCustNo,c.CustName,
a.RMID,a.UnitPrice,a.SRVNo
from Op_ContractPropertyFee a 
left join Op_Contract b on a.RefRP=b.RowPointer
left join Mstr_Customer c on b.ContractCustNo=c.CustNo
where
b.ContractStatus='2' and 
b.FeeStartDate>='2019-03-01' and 
b.FeeStartDate<'2019-03-02' and
b.ContractSPNo='FWC-004' and 
a.SRVNo in('DL-DF-1','DL-SF-1','DL-GTDF','DL-GTSF') and 
b.ContractCreateDate<'2019-03-26 09:00:00'
order by b.FeeStartDate;

--��һ�׶Σ���ͬ¼��ʱ��С��3��26������9�㣬��ͬ�շ�ʱ��Ϊ3��1��
insert into Op_ContractRMRentList(RowPointer,RefRP,RefNo,RMID,SRVNo,FeeStartDate,FeeEndDate,FeeQty,FeeUnitPrice,FeeAmount,FeeStatus,Creator,CreateDate,IsRefund)
select NEWID(),b.RowPointer,a.RowPointer,a.RMID,a.SRVNo,'2019-02-01','2019-02-28',0,a.UnitPrice,0,0,'�����',GETDATE(),0
from Op_ContractPropertyFee a 
left join Op_Contract b on a.RefRP=b.RowPointer
where
b.ContractStatus='2' and 
b.FeeStartDate>='2019-03-01' and 
b.FeeStartDate<'2019-03-02' and
b.ContractSPNo='FWC-004' and 
a.SRVNo in('DL-DF-1','DL-SF-1','DL-GTDF','DL-GTSF') and 
b.ContractCreateDate<'2019-03-26 09:00:00.000';

--��һ���������������
select  b.ContractNo as '��ͬ���',c.CustName as '�ͻ�����'
from Op_ContractPropertyFee a 
left join Op_Contract b on a.RefRP=b.RowPointer
left join Mstr_Customer c on b.ContractCustNo=c.CustNo
where
b.ContractStatus='2' and 
b.FeeStartDate>='2019-03-01' and 
b.FeeStartDate<'2019-03-02' and
b.ContractSPNo='FWC-004' and 
a.SRVNo in('DL-DF-1','DL-SF-1','DL-GTDF','DL-GTSF') and 
b.ContractCreateDate<'2019-03-26 09:00:00.000'
group by b.ContractNo,c.CustName order by b.ContractNo;
--####################################################        �ڶ������ݴ���      ######################################################################
--�ڶ�����ѯ
select b.RowPointer,b.ContractNo,b.ContractCreateDate,b.FeeStartDate,b.ContractCustNo,c.CustName,
a.RMID,a.UnitPrice,a.SRVNo
from Op_ContractPropertyFee a 
left join Op_Contract b on a.RefRP=b.RowPointer
left join Mstr_Customer c on b.ContractCustNo=c.CustNo
where
b.ContractStatus='2' and 
b.FeeStartDate>='2019-03-01' and 
b.FeeStartDate<'2019-03-02' and
b.ContractSPNo='FWC-004' and 
a.SRVNo in('DL-DF-1','DL-SF-1','DL-GTDF','DL-GTSF') and 
b.ContractAuditDate<='2019-03-27 09:00:00' and
b.RowPointer not in (select RefRP from Op_ContractRMRentList where Creator='�����' group by RefRP)
order by b.FeeStartDate;
--�ڶ�������
insert into Op_ContractRMRentList(RowPointer,RefRP,RefNo,RMID,SRVNo,FeeStartDate,FeeEndDate,FeeQty,FeeUnitPrice,FeeAmount,FeeStatus,Creator,CreateDate,IsRefund)
select NEWID(),b.RowPointer,a.RowPointer,a.RMID,a.SRVNo,'2019-02-01','2019-02-28',0,a.UnitPrice,0,0,'�����',GETDATE(),0
from Op_ContractPropertyFee a 
left join Op_Contract b on a.RefRP=b.RowPointer
where
b.ContractStatus='2' and 
b.FeeStartDate>='2019-03-01' and 
b.FeeStartDate<'2019-03-02' and
b.ContractSPNo='FWC-004' and 
a.SRVNo in('DL-DF-1','DL-SF-1','DL-GTDF','DL-GTSF') and 
b.ContractAuditDate<='2019-03-27 09:00:00' and
b.RowPointer not in (select RefRP from Op_ContractRMRentList where Creator='�����' group by RefRP)
--�ڶ����������������
select  b.ContractNo as '��ͬ���',c.CustName as '�ͻ�����'
from Op_ContractPropertyFee a 
left join Op_Contract b on a.RefRP=b.RowPointer
left join Mstr_Customer c on b.ContractCustNo=c.CustNo
where
b.ContractStatus='2' and 
b.FeeStartDate>='2019-03-01' and 
b.FeeStartDate<'2019-03-02' and
b.ContractSPNo='FWC-004' and 
a.SRVNo in('DL-DF-1','DL-SF-1','DL-GTDF','DL-GTSF') and 
b.ContractAuditDate<='2019-03-27 09:00:00' and
b.RowPointer not in (select RefRP from Op_ContractRMRentList where Creator='�����' group by RefRP)
group by b.ContractNo,c.CustName order by b.ContractNo;

--delete from Op_ContractRMRentList where Creator='�����' and CreateDate>='2019-03-27 09:00:00'
--####################################################        ���������ݴ���      ######################################################################

--����������
insert into Op_ContractRMRentList(RowPointer,RefRP,RefNo,RMID,SRVNo,FeeStartDate,FeeEndDate,FeeQty,FeeUnitPrice,FeeAmount,FeeStatus,Creator,CreateDate,IsRefund)
select NEWID(),b.RowPointer,a.RowPointer,a.RMID,a.SRVNo,'2019-02-01','2019-02-28',0,a.UnitPrice,0,0,'�����',GETDATE(),0
from Op_ContractPropertyFee a 
left join Op_Contract b on a.RefRP=b.RowPointer
where
b.ContractStatus='2' and 
b.FeeStartDate>='2019-03-01' and 
b.FeeStartDate<'2019-03-02' and
b.ContractSPNo='FWC-004' and 
a.SRVNo in('DL-DF-1','DL-SF-1','DL-GTDF','DL-GTSF') and 
b.ContractAuditDate<='2019-03-27 11:00:00' and
b.RowPointer not in (select RefRP from Op_ContractRMRentList where Creator='�����' group by RefRP)
--��������ѯ
select b.RowPointer,b.ContractNo,b.ContractCreateDate,b.FeeStartDate,b.ContractCustNo,c.CustName,
a.RMID,a.UnitPrice,a.SRVNo
from Op_ContractPropertyFee a 
left join Op_Contract b on a.RefRP=b.RowPointer
left join Mstr_Customer c on b.ContractCustNo=c.CustNo
where
b.ContractStatus='2' and 
b.FeeStartDate>='2019-03-01' and 
b.FeeStartDate<'2019-03-02' and
b.ContractSPNo='FWC-004' and 
a.SRVNo in('DL-DF-1','DL-SF-1','DL-GTDF','DL-GTSF') and 
b.ContractAuditDate<='2019-03-27 11:00:00' and
b.RowPointer not in (select RefRP from Op_ContractRMRentList where Creator='�����' group by RefRP)
order by b.FeeStartDate;
--�������������������
select  b.ContractNo as '��ͬ���',c.CustName as '�ͻ�����'
from Op_ContractPropertyFee a 
left join Op_Contract b on a.RefRP=b.RowPointer
left join Mstr_Customer c on b.ContractCustNo=c.CustNo
where
b.ContractStatus='2' and 
b.FeeStartDate>='2019-03-01' and 
b.FeeStartDate<'2019-03-02' and
b.ContractSPNo='FWC-004' and 
a.SRVNo in('DL-DF-1','DL-SF-1','DL-GTDF','DL-GTSF') and 
b.ContractAuditDate<='2019-03-27 11:00:00' and
b.RowPointer not in (select RefRP from Op_ContractRMRentList where Creator='�����' group by RefRP)
group by b.ContractNo,c.CustName order by b.ContractNo;
--####################################################        ���������ݴ���      ######################################################################
--����������
insert into Op_ContractRMRentList(RowPointer,RefRP,RefNo,RMID,SRVNo,FeeStartDate,FeeEndDate,FeeQty,FeeUnitPrice,FeeAmount,FeeStatus,Creator,CreateDate,IsRefund)
select NEWID(),b.RowPointer,a.RowPointer,a.RMID,a.SRVNo,'2019-02-01','2019-02-28',0,a.UnitPrice,0,0,'�����',GETDATE(),0
from Op_ContractPropertyFee a 
left join Op_Contract b on a.RefRP=b.RowPointer
where
b.ContractStatus='2' and 
b.FeeStartDate>='2019-03-01' and 
b.FeeStartDate<'2019-03-02' and
b.ContractSPNo='FWC-004' and 
a.SRVNo in('DL-DF-1','DL-SF-1','DL-GTDF','DL-GTSF') and 
--b.ContractAuditDate<='2019-04-04 09:00:00' and
b.RowPointer not in (select RefRP from Op_ContractRMRentList where Creator='�����' group by RefRP)
--��������ѯ
select b.RowPointer,b.ContractNo,b.ContractCreateDate,b.FeeStartDate,b.ContractCustNo,c.CustName,
a.RMID,a.UnitPrice,a.SRVNo
from Op_ContractPropertyFee a 
left join Op_Contract b on a.RefRP=b.RowPointer
left join Mstr_Customer c on b.ContractCustNo=c.CustNo
where
b.ContractStatus='2' and 
b.FeeStartDate>='2019-03-01' and 
b.FeeStartDate<'2019-03-02' and
b.ContractSPNo='FWC-004' and 
a.SRVNo in('DL-DF-1','DL-SF-1','DL-GTDF','DL-GTSF') and 
--b.ContractAuditDate<='2019-04-04 09:00:00' and
b.RowPointer not in (select RefRP from Op_ContractRMRentList where Creator='�����' group by RefRP)
order by b.FeeStartDate;
--�������������������
select  b.ContractNo as '��ͬ���',c.CustName as '�ͻ�����'
from Op_ContractPropertyFee a 
left join Op_Contract b on a.RefRP=b.RowPointer
left join Mstr_Customer c on b.ContractCustNo=c.CustNo
where
b.ContractStatus='2' and 
b.FeeStartDate>='2019-03-01' and 
b.FeeStartDate<'2019-03-02' and
b.ContractSPNo='FWC-004' and 
a.SRVNo in('DL-DF-1','DL-SF-1','DL-GTDF','DL-GTSF') and 
--b.ContractAuditDate<='2019-04-04 09:00:00' and
b.RowPointer not in (select RefRP from Op_ContractRMRentList where Creator='�����' group by RefRP)
group by b.ContractNo,c.CustName order by b.ContractNo;

select  b.ContractNo as '��ͬ���',b.FeeStartDate as '�շѿ�ʼʱ��', c.CustName as '�ͻ�����'
from Op_ContractPropertyFee a 
left join Op_Contract b on a.RefRP=b.RowPointer
left join Mstr_Customer c on b.ContractCustNo=c.CustNo
where
b.ContractStatus='2' and 
b.FeeStartDate>='2019-03-02' and 
--b.FeeStartDate<'2019-03-02' and
b.ContractSPNo='FWC-004' and 
a.SRVNo in('DL-DF-1','DL-SF-1','DL-GTDF','DL-GTSF') and 
b.ContractAuditDate<='2019-03-29 09:00:00' and
b.RowPointer not in (select RefRP from Op_ContractRMRentList where Creator='�����' group by RefRP)
group by b.ContractNo,c.CustName,b.FeeStartDate order by b.FeeStartDate;