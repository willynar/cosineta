USE [trabajo]
GO
/****** Object:  UserDefinedFunction [dbo].[ValidateFilterValue]    Script Date: 25/02/2024 9:14:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[ValidateFilterValue]
(
	@ProductId NVARCHAR(MAX) NULL,
    @ProductName NVARCHAR(MAX) NULL,
    @ProductDescription NVARCHAR(MAX) NULL,
    @ProductImage NVARCHAR(MAX) NULL,
    @TypeId NVARCHAR(MAX) NULL,
    @Price NVARCHAR(MAX) NULL,
    @Ingredients NVARCHAR(MAX) NULL,
    @ProductActive NVARCHAR(MAX) NULL,
	@Review NVARCHAR(MAX) NULL,
    @ApplicationUserId NVARCHAR(MAX) NULL,
    @UserName NVARCHAR(MAX) NULL,
    @UserLastName NVARCHAR(MAX) NULL,
    @FilterValue NVARCHAR(MAX) NULL
)
RETURNS BIT
AS
BEGIN
    DECLARE @Result BIT;

    SET @Result = 
		CASE
			WHEN @FilterValue IS NOT NULL
				THEN
				CASE 
					WHEN (
						@ProductId				LIKE '%' + @FilterValue + '%'  OR
						@ProductName			LIKE '%' + @FilterValue + '%'  OR
						@ProductDescription		LIKE '%' + @FilterValue + '%'  OR
						@ProductImage			LIKE '%' + @FilterValue + '%'  OR
						@TypeId					LIKE '%' + @FilterValue + '%'  OR
						@Price					LIKE '%' + @FilterValue + '%'  OR
						@Ingredients			LIKE '%' + @FilterValue + '%'  OR
						@ProductActive			LIKE '%' + @FilterValue + '%'  OR
						@Review					LIKE '%' + @FilterValue + '%'  OR
						@ApplicationUserId		LIKE '%' + @FilterValue + '%'  OR
						@UserName				LIKE '%' + @FilterValue + '%'  OR
						@UserLastName			LIKE '%' + @FilterValue + '%'  
					)
				THEN 1 
				ELSE 0 
			END
			ELSE 1
		END;

    RETURN @Result;
END;
