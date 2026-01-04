using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRepoApp.Shared.Contracts.Requests;

public record RepositoryUpdateDto(Guid PublicId, string ReposityName, decimal QuotaLimitBytes);
